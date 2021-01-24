    async void GoSecondPageAsync(object obj)
        {
            RootPage.Detail = new NavigationPage(new SecondPage());
            App.MenuIsPresented = false;
        }
