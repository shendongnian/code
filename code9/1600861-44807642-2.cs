    private void SendNotification(string body)
    {
        var intent = new Intent(this, typeof(MainActivity));
        intent.AddFlags(ActivityFlags.ClearTop);
       // var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
        intent.PutExtra("SomeSpecialKey", "some special value");
        Log.Debug(TAG, "Notification Message Body: " + body);
        if (Forms.IsInitialized) { // Ensure XF code has been initialized
            // sends notification to view model
            MessagingCenter.Send((App)Xamarin.Forms.Application.Current, "Increase");
        }
        PendingIntent pendingIntent = PendingIntent.GetActivity(Application.Context, 0, intent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.OneShot);
        var defaultSoundUri = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
        var notificationBuilder = new NotificationCompat.Builder(this)
            .SetSmallIcon(Resource.Drawable.icon)
            .SetContentTitle("Notification")
            .SetContentText(body)
            .SetAutoCancel(true)
            .SetSound(defaultSoundUri)
            .SetContentIntent(pendingIntent);
        var notificationManager = NotificationManager.FromContext(this);
        notificationManager.Notify(0, notificationBuilder.Build());
    }
