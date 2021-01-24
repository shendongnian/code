    using YourProjectNameSpace.Helper
    
    .....
    if (Settings.IsLoggedIn)
    {
        MainPage = new NavigationPage(new MainPage());
    }
    else
    {
        MainPage.DisplayAlert("Your Title","You Message","OK");
        //Or navigate to Login page, like this:  
        //MainPage = new NavigationPage(new LoginPage());
    }
