    AlarmManager alarmManager = (AlarmManager)this.GetSystemService(Context.AlarmService);
    var ALARM_TYPE = AlarmType.RtcWakeup;
    if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
    {
        alarmManager.SetExactAndAllowWhileIdle(ALARM_TYPE, calendar.TimeInMillis, pendingIntent);
    }
    else if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
    {
        alarmManager.SetExact(ALARM_TYPE, calendar.TimeInMillis, pendingIntent);
    }
    else if
    {
        alarmManager.Set(ALARM_TYPE, calendar.TimeInMillis, pendingIntent);
    }
