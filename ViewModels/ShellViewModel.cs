using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EstateZoningApp.Contracts.Services;
using EstateZoningApp.ViewModels.Interfaces;
using EstateZoningApp.Views.Interfaces;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

namespace EstateZoningApp.ViewModels;

public class ShellViewModel : ObservableRecipient
{

    private object CurrentViewModel;

    public ICommand MenuFileExitCommand
    {
        get;
    }

    public ICommand MenuSettingsCommand
    {
        get;
    }

    public ICommand MenuViewsMainCommand
    {
        get;
    }

    public AsyncRelayCommand<XamlRoot> MenuFileSaveChangesCommand
    {
        get;
    }

    public INavigationService NavigationService
    {
        get;
    }

    private bool _isBackEnabled;
    public bool IsBackEnabled
    {
        get => _isBackEnabled;
        set => SetProperty(ref _isBackEnabled, value);
    }

    private bool _isSaveChangesAware;
    public bool IsSaveChangesAware
    {
        get => _isSaveChangesAware;
        set => SetProperty(ref _isSaveChangesAware, value);
    }

    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

        MenuFileExitCommand = new RelayCommand(OnMenuFileExit);
        MenuFileSaveChangesCommand = new AsyncRelayCommand<XamlRoot>(OnFileSaveChanges, CanFileSaveChanges);
        MenuSettingsCommand = new RelayCommand(OnMenuSettings);
        MenuViewsMainCommand = new RelayCommand(OnMenuViewsMain);
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsSaveChangesAware = false;

        IsBackEnabled = NavigationService.CanGoBack;
        if (e.Content is IViewModelPage ivmp)
        {
            CurrentViewModel = ivmp.GetViewModel();
            if (CurrentViewModel is ISaveChangesAware) IsSaveChangesAware = true;
        }

    }

    private void OnMenuFileExit() => Application.Current.Exit();

    private async Task OnFileSaveChanges(XamlRoot root) => await (CurrentViewModel as ISaveChangesAware).SaveChanges(root);

    private bool CanFileSaveChanges(XamlRoot root) => IsSaveChangesAware;

    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainViewModel).FullName!);

}
