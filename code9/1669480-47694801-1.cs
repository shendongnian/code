    public static async void sendPushNotificationApns(ApiController controller, DataObjects.Notification notification)
    {
        // Get the settings for the server project.
        HttpConfiguration config = controller.Configuration;
        MobileAppSettingsDictionary settings =
            controller.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
        // Get the Notification Hubs credentials for the Mobile App.
        string notificationHubName = settings.NotificationHubName;
        string notificationHubConnection = settings
            .Connections[MobileAppSettingsKeys.NotificationHubConnectionString].ConnectionString;
        // Create a new Notification Hub client.
        NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(notificationHubConnection, notificationHubName);
        var apnsNotification = "{\"aps\":{\"alert\":\"" + notification.Descricao + "\"},\"Id\":\"" + notification.Id +
            "\",\"Tipo\":\"" + notification.Tipo + "\",\"Id_usuario\":\"" + notification.Id_usuario +
            "\",\"Informacao\":\"" + notification.Informacao +
            "\",\"Status\":\"" + notification.Status + "\"}";
        
        try
        {
            // Send the push notification and log the results.
            String tag = "_UserId:" + notification.Id_usuario;               
            var result = await hub.SendAppleNativeNotificationAsync(apnsNotification, tag);
            // Write the success result to the logs.
            config.Services.GetTraceWriter().Info(result.State.ToString());
        }
        catch (System.Exception ex)
        {
            // Write the failure result to the logs.
            config.Services.GetTraceWriter().Error(ex.Message, null, "Push.SendAsync Error");
        }
    }
