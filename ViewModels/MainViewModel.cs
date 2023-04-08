using CommunityToolkit.Mvvm.ComponentModel;

namespace EstateZoningApp.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public MainViewModel()
    {

    }

    [ObservableProperty]
    string test;
}
