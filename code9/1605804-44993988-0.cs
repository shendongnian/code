    [BroadcastReceiver(Enabled = true)]
        [IntentFilter(new[] { Android.Content.Intent.ActionTimeTick })]
        public class GridStartBroadcastReceiver : BroadcastReceiver
        {
            public static readonly string GRID_STARTED = "GRID_STARTED";
            public override void OnReceive(Context context, Intent intent)
            {
               if (intent.Action == GRID_STARTED)
                {
             //your logic
                }
            }
        }
