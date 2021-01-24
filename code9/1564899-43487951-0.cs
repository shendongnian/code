    public class App : Application
    {
      public App()
      {
        var nPage = new NavigationPage(new WelcomePage()); // or new LoginPage()
        MainPage = nPage;
      }
    }
