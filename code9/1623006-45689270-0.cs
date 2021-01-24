    AlarmManager manager;
    Intent alarmIntent;
    PendingIntent pendingIntent;
    ...
    //Creat a timer
    private void StartAlarmClockTimer()
    {
         manager = (AlarmManager)GetSystemService(Context.AlarmService);
         alarmIntent = new Intent(Android.Provider.AlarmClock.ActionSetTimer);
         alarmIntent.PutExtra(Android.Provider.AlarmClock.ExtraLength, 2);
         alarmIntent.PutExtra(Android.Provider.AlarmClock.ExtraVibrate, true);
         alarmIntent.PutExtra(Android.Provider.AlarmClock.ExtraMessage, "Custom Text!");
         alarmIntent.PutExtra(Android.Provider.AlarmClock.ExtraSkipUi, true);
         alarmIntent.AddFlags(ActivityFlags.NewTask);
         pendingIntent = PendingIntent.GetActivity(this, 0, alarmIntent, 0);
         manager.SetExact(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime(), pendingIntent);
    };
    //Cancel a timer
    private void CancelAlarmClockTimer()
    {
        manager.Cancel(pendingIntent);
    }
    
