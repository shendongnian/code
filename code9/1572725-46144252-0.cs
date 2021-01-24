    public class AndroidDeviceNetwork : IDeviceNetwork
    {
        private const string UNKNOWNSSID = "<unknown ssid>";
        public NetworkState GetNetworkState()
        {
            var connMgr = Application.Context.GetSystemService(Context.ConnectivityService)
                as ConnectivityManager;
            if (connMgr == null)
                return NetworkState.NoNetwork;
            var activeNetwork = connMgr.ActiveNetworkInfo;
            if (activeNetwork == null || !activeNetwork.IsConnectedOrConnecting)
                return NetworkState.NoNetwork;
            if (activeNetwork.Type == ConnectivityType.Wifi)
                return  NetworkState.WiFi;
            if (activeNetwork.Type == ConnectivityType.Mobile)
                return NetworkState.Mobile;
            return NetworkState.NoNetwork;
        }
        /// <summary>
        /// Detects if the device has wifi turned on (does not take into account if the
        /// device is connected to a wifi network, only the fact its switched on).
        /// </summary>
        /// <returns>True if switched on only. False if not switched on.</returns>
        public bool IsWifiEnabled()
        {
            var wifiManager = Application.Context.GetSystemService(Context.WifiService)
                as WifiManager;
            // Check state is enabled.
            if (wifiManager != null)
                return wifiManager.IsWifiEnabled;
            return false;
        }
        /// <summary>
        /// Detects if the device has MobileData turned on 
        /// </summary>
        /// <returns>True if switched on only. False if not switched on.</returns>
        public bool IsMobileDataEnabled()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var networkInfo = connectivityManager?.ActiveNetworkInfo;
            return networkInfo?.Type == ConnectivityType.Mobile;
        }
        /// <summary>
        /// Checks wifi is switched on AND that its connected (using NetworkId and SSID to 
        /// identify connected).
        /// </summary>
        /// <returns>True if switched on and connected to a wifi network.  False if not switch on 
        /// OR if switched on but not connected.</returns>
        public bool IsWifiConnected()
        {
            var wifiManager = Application.Context.GetSystemService(Context.WifiService) as WifiManager;
            if (wifiManager != null)
            {
                // Check state is enabled.
                return wifiManager.IsWifiEnabled &&
                    // Check for network id equal to -1
                    (wifiManager.ConnectionInfo.NetworkId != -1
                    // Check for SSID having default value of "<unknown SSID>"
                    && wifiManager.ConnectionInfo.SSID != UNKNOWNSSID);
            }
            return false;
        }
    }
