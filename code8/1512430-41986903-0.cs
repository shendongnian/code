        private void SetAlarm(DateTime time, string alarmID, int eventID, bool final)
        {
            if (!final)
            {
                Intent wake = new Intent(this, typeof(Check//Removed//Event));
                wake.PutExtra("alarmID", alarmID);
                PendingIntent temp = PendingIntent.GetBroadcast(this, eventID, wake, PendingIntentFlags.NoCreate);
                if (temp != null)
                {
                    temp.Cancel();
                }
                PendingIntent pending = PendingIntent.GetBroadcast(this, eventID, wake, PendingIntentFlags.UpdateCurrent);
                var alarmMgr = (AlarmManager)GetSystemService(AlarmService);
                TimeSpan span = time - DateTime.Now;
                
                long schedule = (long)(Java.Lang.JavaSystem.CurrentTimeMillis() + span.TotalMilliseconds);
                alarmMgr.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, schedule, pending);
            }
            else
            {//Set Alarm
                Intent wake = new Intent(this, typeof(//Removed//Event));
                wake.PutExtra("alarmID", alarmID);
                PendingIntent temp = PendingIntent.GetBroadcast(this, eventID, wake, PendingIntentFlags.NoCreate);
                if (temp != null)
                {
                    temp.Cancel();
                }
                PendingIntent pending = PendingIntent.GetBroadcast(this, eventID, wake, PendingIntentFlags.UpdateCurrent);
                var alarmMgr = (AlarmManager)GetSystemService(AlarmService);
                TimeSpan span = time - DateTime.Now;
                long schedule = (long)(Java.Lang.JavaSystem.CurrentTimeMillis() + span.TotalMilliseconds);
                alarmMgr.SetExactAndAllowWhileIdle(AlarmType.RtcWakeup, schedule, pending);
            }
        }
    }
