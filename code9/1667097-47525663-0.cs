    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IDataProvider, SQLiteDataProvider>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register(GetNavigationService);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MessageViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
            ...
        }
        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>(Guid.NewGuid().ToString());
        public MessageViewModel MessageViewModel => SimpleIoc.Default.GetInstance<MessageViewModel>(Guid.NewGuid().ToString());
        public SearchViewModel SearchViewModel => SimpleIoc.Default.GetInstance<SearchViewModel>(Guid.NewGuid().ToString());
        public SettingViewModel SettingViewModel => SimpleIoc.Default.GetInstance<SettingViewModel>(Guid.NewGuid().ToString());
        ...
        public INavigationService GetNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure(Pages.MainView.ToString(), typeof(MainPage));
            navigationService.Configure(Pages.MessageView.ToString(), typeof(MessagePage));
            navigationService.Configure(Pages.SearchView.ToString(), typeof(SearchPage));
            navigationService.Configure(Pages.SettingView.ToString(), typeof(SettingPage));
            ...
            return navigationService;
        }
    }
