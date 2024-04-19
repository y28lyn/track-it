using Newtonsoft.Json;
using TrackIT.ViewModel;

namespace TrackIT;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = new ViewModel.MainViewModel();
    }
}