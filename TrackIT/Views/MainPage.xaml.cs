using TrackIT.ViewModel;
using TrackIT.Data;

namespace TrackIt;

public partial class MainPage : ContentPage
{
    private readonly Database database;

    public MainPage(Database database)
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
        this.database = database;
    }
}

