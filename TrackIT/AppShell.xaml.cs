namespace TrackIT;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(TrackItPage), typeof(TrackItPage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));

    }
}
