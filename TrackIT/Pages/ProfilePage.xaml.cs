using TrackIT.ViewModel;
using static TrackIT.MainPage;

namespace TrackIT;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();

        // R�cup�rer les informations de l'utilisateur � partir des pr�f�rences
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
