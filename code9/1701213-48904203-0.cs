        public List<ScanResult> GetWifiNetworks(){
            return WiFiNetworks;
        }
        class WifiReceiver : BroadcastReceiver, IScanReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                WiFiNetworks = wifi.ScanResults.ToList();
            }
        }
