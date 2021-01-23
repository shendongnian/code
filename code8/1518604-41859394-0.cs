    public Action SuccessfulLoginAction
    {
        get
        {
            return new Action(() =>
            {
                //var masterDetailPage = Application.Current.MainPage as MasterDetailPage;
                //masterDetailPage.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Painel)));
                //masterDetailPage.IsPresented = false;
                _NavPage.Navigation.PopAsync();
                _NavPage.Navigation.PushAsync(new MainPage());
            });
        }
    }
