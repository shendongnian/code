    [Service]
    public class WidgetService : Service
    {
        bool isStarted;
        public override StartCommandResult OnStartCommand(Android.Content.Intent 
        intent, StartCommandFlags flags, int startId)
        {
            if (!isStarted)
			{
                SendPushNotification();
                isStarted = true;
            }
            return StartCommandResult.NotSticky;
        }
        //Only will be called if stopWithTask attribute is set to false
        public override void OnTaskRemoved(Intent rootIntent)
        {
            
            // Remove the notification from the status bar.
            base.OnTaskRemoved(rootIntent);
        }
        public override void OnDestroy()
		{
			// We need to shut things down.
			// Remove the notification from the status bar.
			isStarted = false;
			base.OnDestroy();
		}
    }
