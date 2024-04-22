using System.Text;
using System.Text.Json;

namespace TrackIT;

public partial class MainPage : ContentPage
{
    private readonly HttpClient _httpClient;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new TrackIT.ViewModel.MainViewModel();
        _httpClient = new HttpClient();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        var formData = new Dictionary<string, string>
    {
        { "action", "login" },
        { "email", email },
        { "password", password }
    };
        var json = JsonSerializer.Serialize(formData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync("http://10.0.2.2/maui_api/api.php", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LoginResult>(responseContent);

                if (result != null && result.success && result.user != null)
                {
                    Preferences.Set("UserId", result.user.id);
                    Preferences.Set("UserName", result.user.nom);
                    Preferences.Set("UserFirstName", result.user.prenom);

                    await DisplayAlert("Succès", "Connexion réussie.", "OK");

                    await Task.Delay(1000);

                    await Navigation.PushAsync(new TrackItPage());
                }

                else
                {
                    await DisplayAlert("Erreur", "Identifiants incorrects.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Une erreur s'est produite lors de la communication avec le serveur.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", $"Une erreur s'est produite : {ex.Message}", "OK");
        }
    }

    // Classe modèle pour désérialiser la réponse JSON de l'API
    public class LoginResult
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public User? user { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string? nom { get; set; }
        public string? prenom { get; set; }
    }
}