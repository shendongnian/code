    // In MainPage:
    public static MainPage Instance {
        // This will return null when your current page is not a MainPage instance!
        get { return (Window.Current.Content as Frame).Content as MainPage; }
    }
    // Now in HomePage it's only:
    MainPage.Instance.OpenTab(TabContent.Settings);
