    //get unique number through TelephonyManager
    //use this method, we need to add android.permission.READ_PHONE_STATE permission
    var telephonymanager = this.GetSystemService(Context.TelephonyService) as TelephonyManager;
    var imsid = telephonymanager.SubscriberId;
    System.Diagnostics.Debug.WriteLine("imsid: " + imsid);
    
    //get mac address through WifiManager
    //use this method, we need to add android.permission.ACCESS_WIFI_STATE permission
    var wifimanager = this.GetSystemService(Context.WifiService) as WifiManager;
    var info = wifimanager.ConnectionInfo;
    var macaddress = info.MacAddress;
    System.Diagnostics.Debug.WriteLine("mac address: " + macaddress);
    
    //get Android_ID use Android Provider
    var deviceid = Android.Provider.Settings.Secure.GetString(this.ContentResolver,
        Android.Provider.Settings.Secure.AndroidId);
    System.Diagnostics.Debug.WriteLine("device id: " + deviceid);
