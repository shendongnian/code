    using Windows.Storage;
    if (e.PrelaunchActivated == false)
    {
        if (rootFrame.Content == null)
        {
            IPropertySet roamingProperties = ApplicationData.Current.RoamingSettings.Values;
            if (roamingProperties.ContainsKey("FirstTimePage"))
            {
                // regular visit
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            else
            {
                // first time visit
                rootFrame.Navigate(typeof(RegionPage), e.Arguments);
                roamingProperties["FirstTimePage"] = bool.TrueString;       
            }
        }
        // Ensure the current window is active
        Window.Current.Activate();
    }
