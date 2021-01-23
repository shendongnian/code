    //Root Page
    public class App
    {
        public static Page GetMainPage()
        {
            return new NavigationPage(new LoginPage());
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
                Navigation.PushAsync(new CreatedPage());
            }
        }
    //Pop to root
    
    public class CreatedPage : ContentPage
        {
    
            private void CreatedButtonOnClicked(object sender, EventArgs eventArgs)
            {
                Navigation.PopToRootAsync();
            }
    
        }
