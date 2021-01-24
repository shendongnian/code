    public partial class App : Application
        {
            public static RootPage RootPage { get; private set; } //DON'T DO THIS, 
                                                                  //FIND A BETTER WAY 
            public App()
            {
                InitializeComponent();
    
                //NavigationPage = new NavigationPage(new MainPage());
                RootPage = new RootPage();
                MenuPage menuPage = new MenuPage(RootPage.vm);
    
                RootPage.Master = menuPage;
                RootPage.Detail = new NavigationPage(new MainPage());// NavigationPage;
                MainPage = RootPage;
            }
    
            protected override void OnStart()
            {
                // Handle when your app starts
            }
    
            protected override void OnSleep()
            {
                // Handle when your app sleeps
            }
    
            protected override void OnResume()
            {
                // Handle when your app resumes
            }
        }
