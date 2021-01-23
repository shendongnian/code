    [BroadcastReceiver]
        [IntentFilter(new[] { Intent.ActionBootCompleted }, Categories = new[] { Intent.CategoryDefault })]
        public class BootCompletedIntentReceiver : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                if (intent.Action == Intent.ActionBootCompleted)
                {
                    context.StartService(new Intent(context, typeof(YourService)));
                }
            }
        }
