            private void CreateNotification(string title, string desc, Context context, Intent intent)
            {
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
    
                Notification.Builder builder = new Notification.Builder(context)
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent)
                    .SetContentTitle(title)
                    .SetContentText(desc)
                    .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
                    .SetSmallIcon(Resource.Drawable.Icon);
                            
                var notification = builder.Build();            
                var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
    
                const int notificationId = 0;
                notificationManager.Notify(notificationId, notification);   
            }
