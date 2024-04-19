namespace TrackIT;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModel.MainViewModel();
    }
}