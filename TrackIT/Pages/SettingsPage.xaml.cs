namespace TrackIT;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        BindingContext = new ViewModel.SettingsViewModel();
    }

    private async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        // Effacer les informations de l'utilisateur sauvegardées dans les préférences
        Preferences.Clear();

        // Naviguer vers la page principale (MainPage)
        await Navigation.PushAsync(new MainPage());
    }
}
