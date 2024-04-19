namespace TrackIT;

public partial class TrackItPage : ContentPage
{
	public TrackItPage()
	{
		InitializeComponent();
        BindingContext = new ViewModel.MainViewModel();
	}
}