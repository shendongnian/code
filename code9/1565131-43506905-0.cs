	[BroadcastReceiver]
	[IntentFilter(new string[] { WifiManager.NetworkStateChangedAction, WifiManager.WifiStateChangedAction })]
	public class NetworkBroadcastReceiver : BroadcastReceiver
	{
		readonly WifiManager wifiManager;
		public static string LastSSID;
		public NetworkBroadcastReceiver(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
		}
		public NetworkBroadcastReceiver()
		{
			wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
		}
		public override void OnReceive(Context context, Intent intent)
		{
			string currentSSID = null;
			if (WifiManager.NetworkStateChangedAction == intent.Action)
			{
				var netInfo = (NetworkInfo)intent.GetParcelableExtra(WifiManager.ExtraNetworkInfo);
				var netInfoDetailed = netInfo.GetDetailedState();
				if (netInfo.IsConnected || netInfoDetailed == NetworkInfo.DetailedState.Connected) 
				{
					currentSSID = wifiManager.ConnectionInfo.SSID;
				}
				else if (!netInfo.IsConnected)
				{
					currentSSID = null;
				}
			}
			if (WifiManager.WifiStateChangedAction == intent.Action)
			{
				currentSSID = GetCurrentSSID();
			}
			if (LastSSID != currentSSID)
			{
				// Do something on SSID change....
				Toast.MakeText(context, $"Wireless SSID changed, from:{LastSSID} to:{currentSSID}", ToastLength.Long).Show();
				LastSSID = currentSSID;
			}
		}
		public static string GetCurrentSSID()
		{
			var wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
			if (wifiManager.ConnectionInfo.SupplicantState == SupplicantState.Completed)
			{
				return wifiManager.ConnectionInfo.SSID;
			}
			return null;
		}
	}
