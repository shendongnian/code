    [BroadcastReceiver(Enabled =true)]
    [IntentFilter( new [] { "android.net.wifi.STATE_CHANGE"})]
    public class WifiReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
           NetworkInfo info=intent.GetParcelableExtra(WifiManager.ExtraNetworkInfo) as NetworkInfo;
            if (info != null && info.IsConnected)
            {
                
                ConnectivityManager manager =(ConnectivityManager) context.GetSystemService(Context.ConnectivityService);
                NetworkInfo netInfo = (NetworkInfo)manager.GetNetworkInfo(ConnectivityType.Wifi);
                AudioManager audioManager = (AudioManager)context.GetSystemService(Context.AudioService);
                if (netInfo.IsConnectedOrConnecting)
                {
                    Toast.MakeText(context, "Wifi is connected", ToastLength.Short).Show();
                    audioManager.RingerMode = RingerMode.Silent;
                }
                else
                {
                    audioManager.RingerMode = RingerMode.Normal;
                }
            }
        }
    }
