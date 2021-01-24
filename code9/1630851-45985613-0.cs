    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }
        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<PageA>();
            Container.RegisterTypeForNavigation<PageB>();
            Container.RegisterTypeForNavigation<PageC>();
            Container.RegisterTypeForNavigation<PageD>();
            Container.RegisterType<ITsApiService, TsApiService>();
        }
    }
