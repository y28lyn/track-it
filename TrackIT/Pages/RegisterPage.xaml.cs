using System.Text;
using System.Text.Json;

namespace TrackIT.Pages;

public partial class RegisterPage : ContentPage
{
    private readonly HttpClient _httpClient;

    public RegisterPage()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }
    private async void OnSignUpButtonClicked(object sender, EventArgs e)
    {
        var newUser = new Dictionary<string, string>
        {
            {"action", "register"},
            {"nom", LastNameEntry.Text},
            {"prenom", FirstNameEntry.Text},
            {"email", EmailEntry.Text},
            {"mot_de_passe", PasswordEntry.Text}
        };

        var json = JsonSerializer.Serialize(newUser);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            HttpResponseMessage response = await _httpClient.PostAsync("http://10.0.2.2/maui_api/api.php", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ResponseModel>(responseContent);
                if (result?.success ?? false)
                {
                    await DisplayAlert("Succ�s", "Inscription r�ussie", "OK");
                    // Ajouter la logique de navigation apr�s inscription
                }
                else
                {
                    await DisplayAlert("Erreur", "Inscription �chou�e", "OK");
                }
            }
        }
        catch (Exception exception)
        {
            await DisplayAlert("Erreur", "Une exception s'est produite: " + exception.Message, "OK");
        }
    }

    private class ResponseModel
    {
        public bool success { get; set; }
        public string? message { get; set; }
    }
}