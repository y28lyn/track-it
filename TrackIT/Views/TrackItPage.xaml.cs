using TrackIT.ViewModel;

namespace TrackIT;

public partial class TrackItPage : ContentPage
{
	public TrackItPage(TrackItViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}