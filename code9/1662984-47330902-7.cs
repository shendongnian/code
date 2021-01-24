    [BroadcastReceiver]
    public class RepeatingAlarm : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //Every time the `RepeatingAlarm` is fired, set the next alarm
            var intentForRepeat = new Intent(context, typeof(RepeatingAlarm));
            var source = PendingIntent.GetBroadcast(context, 0, intent, 0);
            var am = (AlarmManager)Android.App.Application.Context.GetSystemService(Context.AlarmService);
            am.SetExactAndAllowWhileIdle(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + 15 * 1000, source);
            Toast.MakeText(context, "repeating_received and after 15s another alarm will be fired", ToastLength.Short).Show();
        }
    }
    
