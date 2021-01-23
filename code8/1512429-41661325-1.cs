    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var launchIntent = new Intent(Application.Context, typeof(SplashActivity)); //use your starting activity
                var launchPendingIntent = PendingIntent.GetActivity(Application.Context, requestCode, launchIntent,
                    PendingIntentFlags.CancelCurrent); //use the same request code as for 'pending'
                var alarmInfo = new AlarmManager.AlarmClockInfo(cal.TimeInMillis, launchPendingIntent);
                alarmMgr.SetAlarmClock(alarmInfo, pending);
            }
    else if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            alarmMgr.SetExact(AlarmType.RtcWakeup, cal.TimeInMillis, pending);
    else
            alarmMgr.Set(AlarmType.RtcWakeup, cal.TimeInMillis, pending);
