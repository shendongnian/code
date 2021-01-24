    [BroadcastReceiver]
    public class NotificationBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == "Action")
            {
                // TODO: Grab extras from the Intent as needed.
                var key = intent.GetStringExtra("key");
                // TODO: Handle notification closing here...
            }
        }
     }
