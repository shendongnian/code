	[BroadcastReceiver(Name = "com.sushhangover.OutgoingCallBroadcastReceiver")]
	[IntentFilter(new[] { Intent.ActionNewOutgoingCall, TelephonyManager.ActionPhoneStateChanged })]
	public class OutgoingCallBroadcastReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			switch (intent.Action)
			{
				case Intent.ActionNewOutgoingCall:
					var outboundPhoneNumber = intent.GetStringExtra(Intent.ExtraPhoneNumber);
					Toast.MakeText(context, $"Started: Outgoing Call to {outboundPhoneNumber}", ToastLength.Long).Show();
					break;
				case TelephonyManager.ActionPhoneStateChanged:
					var state = intent.GetStringExtra(TelephonyManager.ExtraState);
					if (state == TelephonyManager.ExtraStateIdle)
						Toast.MakeText(context, "Phone Idle (call ended)", ToastLength.Long).Show();
					else if (state == TelephonyManager.ExtraStateOffhook)
						Toast.MakeText(context, "Phone Off Hook", ToastLength.Long).Show();
					else if (state == TelephonyManager.ExtraStateRinging)
						Toast.MakeText(context, "Phone Ringing", ToastLength.Long).Show();
					else if (state == TelephonyManager.ExtraIncomingNumber)
					{
						var incomingPhoneNumber = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
						Toast.MakeText(context, $"Incoming Number: {incomingPhoneNumber}", ToastLength.Long).Show();
					}
					break;
				default:
					break;
			}
		}
	}
