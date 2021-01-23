    namespace NameSpace
    {
        // Tabbed Detail Page
        [MvxTabbedPagePresentation(Title = "Home", Icon = "ic_home_black.png")]
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class HomePage : MvxContentPage<HomeViewModel>
        {
            public HomePage()
            {
                InitializeComponent();
            }
        }
        // Tabbed Root Page
        [MvxTabbedPagePresentation(TabbedPosition.Root, WrapInNavigationPage = true)]
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class TabbedPage : MvxTabbedPage<TabbedViewModel>
        {
            public TabbedProjectDetailsPage()
            {
                InitializeComponent();
            }
        }
        // Tabbed Detail ViewModel
        public class HomeViewModel : MvxViewModel
        {
            IMvxNavigationService _navigation;
            public HomeViewModel(IMvxNavigationService navigation)
            {
                _navigation = navigation;
            }
        }
        // Tabbed Root ViewModel
        public class TabbedViewModel : MvxNavigationViewModel
        {
            public TabbedProjectDetailsViewModel(IMvxLogProvider log, IMvxNavigationService navigation) : base(log, navigation)
            {
            }
            MvxCommand _navHome;
            public ICommand NavigateHome
            {
                get
                {
                    _navHome = _navHome ?? new MvxCommand(async () =>
                    {
                        await NavigationService.Navigate<HomeViewModel>();
                    });
                    return _navHome;
                }
            }
    
            public void ShowViewModels()
            {
                this.NavigateHome.Execute(null);
            }
            bool appeared = false;
            public override void ViewAppearing()
            {
                base.ViewAppearing();
                if (!appeared)
                {
                    ShowViewModels();
                }
                appeared = true;
            }
        }
    }
