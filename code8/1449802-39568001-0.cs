    public static string getSSID()
    {
        string tempSSID = "";
        try
        {
            using (var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
            {
                using (var wifiManager = activity.Call<AndroidJavaObject>("getSystemService", "wifi"))
                {
                    tempSSID = wifiManager.Call<AndroidJavaObject>("getConnectionInfo").Call<string>("getSSID");
                }
            }
        }
        catch (Exception e)
        {
        }
        return tempSSID;
    }
    public static string getBSSID()
    {
        string tempBSSID = "";
        try
        {
            using (var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
            {
                using (var wifiManager = activity.Call<AndroidJavaObject>("getSystemService", "wifi"))
                {
                    tempBSSID = wifiManager.Call<AndroidJavaObject>("getConnectionInfo").Call<string>("getBSSID");
                }
            }
        }
        catch (Exception e)
        {
        }
        return tempBSSID;
    }
