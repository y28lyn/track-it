using System.Windows.Input;
using TrackIT;

public class MainViewModel
{
    public ICommand NavigateToTrackIt { get; }
    public ICommand NavigateToProfile { get; }
    public ICommand NavigateToSettings { get; }


    public MainViewModel()
    {
        NavigateToTrackIt = new Command(async () => await TrackItPage());
        NavigateToProfile = new Command(async () => await ProfilePage());
        NavigateToSettings = new Command(async () => await SettingsPage());
    }

    private async Task TrackItPage()
    {
        await Shell.Current.GoToAsync(nameof(TrackItPage));
    }

    private async Task ProfilePage()
    {
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }

    private async Task SettingsPage()
    {
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}

