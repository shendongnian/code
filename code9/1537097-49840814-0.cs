     public static MyMasterDetail RootPage()
    {
        return (MyMasterDetail)Current.MainPage;
    }
    
    public static void NavigateToHomePage()
    {
        try
        {
    
    
            MainPage homePage = new MainPage();
            MyMasterDetail masterDetailRootPage = (MyMasterDetail)Application.Current.MainPage;
            masterDetailRootPage.Detail = new NavigationPage(homePage);
            masterDetailRootPage.IsPresented = false;
    
            Current.MainPage = masterDetailRootPage;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("!!! NavigateToHomePage() Exception !!!");
            Debug.WriteLine("Exception Description: " + ex);
        }
    }
