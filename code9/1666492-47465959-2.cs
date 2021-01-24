        Notification.Builder builder = new Notification.Builder(Xamarin.Forms.Forms.Context);
        Intent intent = new Intent(Xamarin.Forms.Forms.Context, typeof(MainActivity));
        Bundle bundle = new Bundle();
        // if we want to navigate to Page1:
        bundle.PutString("pageName", "Page1");
        intent.PutExtras(bundle);
        PendingIntent pIntent = PendingIntent.GetActivity(Xamarin.Forms.Forms.Context, 0, intent, 0);
        builder.SetContentTitle(title)
               .SetContentText(text)
               .SetSmallIcon(Resource.Drawable.icon)
               .SetContentIntent(pIntent);
        var manager = (NotificationManager)Xamarin.Forms.Forms.Context.GetSystemService("notification");
            manager.Notify(1, builder.Build());
