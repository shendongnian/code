    public override void OnReceive(Context context, Intent intent) 
    {
        PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
        PowerManager.WakeLock wl = pm.NewWakeLock(WakeLockFlags.Partial, "");
        wl.Acquire();
        Vibrator v = (Vibrator)context.GetSystemService(Context.VibratorService);
        v.Vibrate(1000);
        Intent i = new Intent(context, typeof(MainActivity));
        i.AddFlags(ActivityFlags.NewTask);
        i.PutExtra("alarmIntent",Intent.Data);
        context.StartActivity(i);
        this.FinishActivity(0);
    }
