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
    //Push second page into stack
    
    public class LoginPage : ContentPage
        {            
            private void SignupButtonOnClicked(object sender, EventArgs eventArgs)
            {
                Navigation.PushAsync(new SignupPage());
            }
        }
    
    //Push third page into stack
    
    public class SignupPage : ContentPage
        {            
            private void CreatedButtonOnClicked(object sender, EventArgs eventArgs)
            {
                Navigation.PushModalAsync(new CreatedPage());
            }
        }
    //Pop to root
    
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
