             customReceiver = new CustomActionReceiver();
             //Create intent for action 1 (ARCHIVE)
             var actionIntent1 = new Intent();
             actionIntent1.SetAction("ARCHIVE");
             var pIntent1 = PendingIntent.GetBroadcast(context, 0, actionIntent1, PendingIntentFlags.CancelCurrent);
             //Create intent for action 2 (REPLY)
             var actionIntent2 = new Intent();
             actionIntent2.SetAction("REPLY");
             var pIntent2 = PendingIntent.GetBroadcast(context, 0, actionIntent2, PendingIntentFlags.CancelCurrent);
             Intent resultIntent = context.PackageManager.GetLaunchIntentForPackage(context.PackageName);
             var contentIntent = PendingIntent.GetActivity(context, 0, resultIntent, PendingIntentFlags.CancelCurrent);
             var builder = new NotificationCompat.Builder(context)
            .SetContentIntent(contentIntent).SetSmallIcon(Resource.Drawable.ic_launcher)
            .SetContentTitle(title)
            .SetStyle(style).SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
            .AddAction(Resource.Drawable.tick_notify, "ARCHIVE", pIntent1)
            .AddAction(Resource.Drawable.cancel_notify, "REPLY", pIntent2)
            .SetAutoCancel(true);
            
            builder.SetDefaults((int)(NotificationDefaults.Sound | NotificationDefaults.Vibrate));
            //Add intent filters for each action and register them on a broadcast receiver
            var intentFilter = new IntentFilter();
            intentFilter.AddAction("ARCHIVE");
            intentFilter.AddAction("REPLY");
           
            context.RegisterReceiver(customReceiver, intentFilter);
            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(0, builder.Build());
