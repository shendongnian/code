    rootFrame = new Frame();
    if(AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Team")
    {
        // surface hub
        rootFrame.Navigate(typeof(MainPageForSurfaceHub), e.Arguments)
    }
    else
    {
        rootFrame.Navigate(typeof(MainPage), e.Arguments)
    }
