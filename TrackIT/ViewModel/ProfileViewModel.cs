using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using static TrackIT.MainPage;

namespace TrackIT.ViewModel
{
    public class ProfileViewModel : ObservableObject
    {
        private User? _user;
        public User? User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ICommand NavigateToTrackIt { get; }
        public ICommand NavigateToProfile { get; }
        public ICommand NavigateToSettings { get; }

        public ProfileViewModel()
        {
            _user = new User();
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
}
