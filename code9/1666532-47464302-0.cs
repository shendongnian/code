    if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
    {
        var statusBar = StatusBar.GetForCurrentView();
        if (statusBar != null)
            statusBar.ForegroundColor = Colors.Red;
    }
