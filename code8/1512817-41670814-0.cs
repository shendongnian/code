     class NotifyEvent : Service
        {
            [return: GeneratedEnum]
            public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
            {
                new Task(() => {
    
                    PendingIntent pIntent = PendingIntent.GetActivity(this, 0, intent, 0);
                    Notification.Builder builder = new Notification.Builder(this);
                    builder.SetContentTitle("hello");
                    builder.SetContentText("hello");
                    builder.SetSmallIcon(Resource.Drawable.Icon);
                    builder.SetPriority(1);
                    builder.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);
                    builder.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis());
                    Notification notifikace = builder.Build();
                    NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
                    const int notificationId = 0;
                    notificationManager.Notify(notificationId, notifikace);
    
                }).Start();
                return StartCommandResult.Sticky;
            }
    
            public override IBinder OnBind(Intent intent)
            {
                return null;
            }
            public override void OnTaskRemoved(Intent rootIntent)
            {
                Intent restartService = new Intent(ApplicationContext, typeof(NotifyEvent));
                restartService.SetPackage(PackageName);
                var pendingServiceIntent = PendingIntent.GetService(ApplicationContext, 0, restartService, PendingIntentFlags.UpdateCurrent);
                AlarmManager alarm = (AlarmManager)ApplicationContext.GetSystemService(Context.AlarmService);
                alarm.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 1000, pendingServiceIntent);
    
                System.Console.WriteLine("service OnTaskRemoved");
                base.OnTaskRemoved(rootIntent);
            }
        }
