using TrackIT.ViewModel;
using static TrackIT.MainPage;

namespace TrackIT;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();

        // Récupérer les informations de l'utilisateur à partir des préférences
        int userId = Preferences.Get("UserId", -1);
        string userName = Preferences.Get("UserName", "");
        string userFirstName = Preferences.Get("UserFirstName", "");

        // Initialiser le contexte de liaison avec les informations de l'utilisateur
        User userInfo = new User
        {
            id = userId,
            nom = userName,
            prenom = userFirstName
        };
        BindingContext = new ProfileViewModel { User = userInfo };
    }
}
