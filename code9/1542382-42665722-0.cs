    // Request Permissions
    if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
    {
        // Request Permissions
        UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound, (granted, error) =>
        {
            // Do something if needed
        });
    }
    else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
    {
        var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
    
        app.RegisterUserNotificationSettings(notificationSettings);
    }
