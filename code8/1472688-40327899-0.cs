    if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
    {
        var titleBar = ApplicationView.GetForCurrentView().TitleBar;
        if (titleBar != null)
        {
            titleBar.ButtonBackgroundColor = Colors.DarkBlue;
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.BackgroundColor = Colors.Blue;
            titleBar.ForegroundColor = Colors.White;
        }
    }
