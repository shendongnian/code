    private void SendIOSPushNotification()
    {
        try
        {
             //Get Certificate
             var appleCert = System.IO.File.ReadAllBytes(Server.MapPath("~/App_Data/Certificates_new.p12"));
             // Configuration (NOTE: .pfx can also be used here)
             var config = new ApnsConfiguration(ApnsConfiguration.ApnsServer## Heading ##Environment.Sandbox, appleCert, "YourCertificatePassword");
             // Create a new broker
             var apnsBroker = new ApnsServiceBroker(config);
             // Wire up events
             apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
             {
                 aggregateEx.Handle(ex =>
                 {
                     // See what kind of exception it was to further diagnose
                     if (ex is ApnsNotificationException)
                     {
                         var notificationException = (ApnsNotificationException)ex;
                         // Deal with the failed notification
                         var apnsNotification = notificationException.Notification;
                         var statusCode = notificationException.ErrorStatusCode;
                         Console.WriteLine($"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}");
                     }
                     else
                     {
                         // Inner exception might hold more useful information like an ApnsConnectionException			
                         Console.WriteLine($"Apple Notification Failed for some unknown reason : {ex.InnerException}");
                     }
                     // Mark it as handled
                     return true;
                 });
             };
             apnsBroker.OnNotificationSucceeded += (notification) =>
             {
                 Console.WriteLine("Apple Notification Sent!");
             };
             var fbs = new FeedbackService(config);
             fbs.FeedbackReceived += (string deviceToken, DateTime timestamp) =>
             {
                 lblResult.Text = deviceToken +" Expired";
                 // Remove the deviceToken from your database
                 // timestamp is the time the token was reported as expired
             };
             // Start Proccess 
             apnsBroker.Start();
             //Device Token
             //string _deviceToken = "8b5f6b908ae3d84a3a9778b1f5f40cc73b33fe2  ?    5431e41702cee6e90c599f1e3";
             string[] deviceTokens = "8b5f6b908ae3d84a3a9778b1f5f40cc73b33fe25431e41702cee6e90c599f1e3,0592798256a0d2f9e00ea366d5bd3595789fa0f551431f1d707cab76d933c25c".Split(',');
             foreach (string _deviceToken in deviceTokens)
             {
                 apnsBroker.QueueNotification(new ApnsNotification
                 {
                     DeviceToken = _deviceToken,
                     Payload = JObject.Parse(("{\"aps\":{\"badge\":1,\"sound\":\"oven.caf\",\"category\":\"NEW_MESSAGE_CATEGORY\",\"alert\":\"" + (txtMessage.Text.Trim() + "\"}}")))
                 });
             }
             apnsBroker.Stop();
             //lblResult.Text = "Messages sent";
         }
         catch (Exception)
         {
             throw;
         }
    }
