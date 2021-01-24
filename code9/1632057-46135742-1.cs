    public class MainMenuPageViewModel : Mvvm.ViewModelBase
    {
        ObservableCollection<NavigationMenuButtonTemplateViewModel> _NavMenuButtonVMs = default(ObservableCollection<NavigationMenuButtonTemplateViewModel>);
        public MainMenuPageViewModel()
        {
            Shell.HamburgerMenu.IsFullScreen = false;
            NavMenuButtonVMs = GetNavMenuButtonInfo();
        }
        public string Title => GetLocalizeString("MainMenuPageViewModelTitle");
        public ObservableCollection<NavigationMenuButtonTemplateViewModel> NavMenuButtonVMs
        {
            get { return _NavMenuButtonVMs; }
            private set { Set(ref _NavMenuButtonVMs, value); }
        }
        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            NavigationService.ClearHistory();
            return base.OnNavigatedToAsync(parameter, mode, state);
        }    
    }
