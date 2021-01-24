        protected override async void OnMessage(Context context, Intent intent)
        {
        Log.Info(MyBroadcastReceiver.TAG, "GCM Message Received!");
            await Task.Delay(1000);
            var msg = new System.Text.StringBuilder();
            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }
            string messageText = intent.Extras.GetString("message");
            if (!string.IsNullOrEmpty(messageText))
            {
               createNotification("New hub message!", messageText);
            }
            else
            {
               createNotification("Unknown message details", msg.ToString());
            }
        }`
 
