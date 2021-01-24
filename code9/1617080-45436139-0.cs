    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(AndroidSyncBackgroundService )), 0);
                AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
                alarm.Cancel(pintent);
            }
