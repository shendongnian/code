    var manager =
        (NotificationManager)context.GetSystemService(Context.NotificationService);
    
    var intent =
        context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
    intent.AddFlags(ActivityFlags.ClearTop);
    
    var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.UpdateCurrent);
    
    var message = "Hello, Sigma!";
    var builder = new NotificationCompat.Builder(context)
        .SetSmallIcon(Android.Resource.Drawable.TitleBar)
        .SetContentTitle("Hello!")
        .SetStyle(new NotificationCompat.BigTextStyle().BigText(message))
        .SetContentText(message)
        .SetContentIntent(pendingIntent);
    
    manager.Notify(1, builder.Build());
