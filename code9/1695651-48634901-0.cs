    ((Xamarin.Forms.NavigationPage)MyProject.App.Current.MainPage).Pushed += (s, e) => 
    {
        if (e.Page is ContentPage)
        {
            // Do what you gotta do
        }
        // or, for a specific page:
        if (e.Page is MyProject.Views.MyCustomPage)
        {
            // Do what you gotta do
        }
    };
