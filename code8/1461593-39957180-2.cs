    public partial class MySplashScreen : ContentPage
    {
     public MySplashScreen()
        {
             InitializeComponent();
    
             CheckForAutoLogin();
         }
    private async void CheckForAutoLogin()
      {
        if (Settings.UserName != string.Empty && Settings.Password != string.Empty)
           {
               //Redirect to you desired page
           }
        else
           {
               //Redirect to login page.
           }
      }
    }
