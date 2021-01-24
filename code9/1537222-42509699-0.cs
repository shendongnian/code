    void IPushNotificationListener.OnMessage(JObject parameters, DeviceType deviceType)
        {
            try
            {
                
                Intent intent = new Intent(Android.App.Application.Context, typeof(MainActivity));
                Intent[] intar = { intent };
                PendingIntent pintent = PendingIntent.GetActivities(Android.App.Application.Context, 0, intar, 0);
                intent.SetAction("notification");
				//Json Response Recieved 
                Dictionary<string, string> results = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameters.ToString());
                Notification.Builder builder = new Notification.Builder(Android.App.Application.Context)
         .SetContentTitle(results["contentTitle"])
         .SetContentText(results["message"])
         .SetContentIntent(pintent)
         .SetSmallIcon(Resource.Drawable.icon);
                // Build the notification:
                Notification notification = builder.Build();
                //Clear notification on click
                notification.Flags = NotificationFlags.AutoCancel;
                // Get the notification manager:
                NotificationManager notificationManager =
                    Android.App.Application.Context.GetSystemService(PushNotificationService.NotificationService) as NotificationManager;
               //notificationId  need to be unique for each message same ID will update existing message
                int notificationId = Convert.ToInt32(results["Id"]);
                // Publish the notification:
                notificationManager.Notify(notificationId, notification);
            }
            catch (Exception)
            {
            }
        }
