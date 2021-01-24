	[BroadcastReceiver(Enabled = true)]
	[IntentFilter(new[] { Intent.ActionBootCompleted })]	
	public class BootBroadcastReceiver : BroadcastReceiver
	{
		const string TAG = "SushiHangover";
		public override void OnReceive(Context context, Intent intent)
		{
			Log.Debug(TAG, $"OnReceive");
			var serviceIntent = new Intent(context, typeof(BootService));
			context.StartService(serviceIntent);
		}
	}
