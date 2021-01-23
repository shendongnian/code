    //Master Detail Page
      public class RootPage : MasterDetailPage
        {
            MenuPage menuPage;
    
            public RootPage()
            {
                menuPage = new MenuPage(this);
                Master = menuPage;
                Detail = new NavigationPage(new HomePage());
            }
        }
----------
    //Set the Root Page
    public class App : Application
    {
        public App()
        {
           InitializeComponent ();
           if(NewUser || NotLoggedIn)
              {
                 MainPage = new LoginPage();
              }
           else
              {
                 MainPage = new RootPage();
              }
        }
    }
    
    public class LoginPage : ContentPage
        {            
            private void SignupButtonOnClicked(object sender, EventArgs eventArgs)
            {
                Navigation.PushAsync(new SignupPage());
            }
        }
    
    
    public class SignupPage : ContentPage
        {            
            private void CreatedButtonOnClicked(object sender, EventArgs eventArgs)
            {
                Navigation.PushModalAsync(new CreatedPage());
            }
        }
    // Set the Login Page
    
    public class CreatedPage : ContentPage
        {
    
            private void CreatedButtonOnClicked(object sender, EventArgs eventArgs)
            {
                Navigation.PushModalAsync(new LoginPage());
                //Special Handel for Android Back button
                if (Device.OS == TargetPlatform.Android)
                Application.Current.MainPage = new LoginPage();
            }
    
        }
