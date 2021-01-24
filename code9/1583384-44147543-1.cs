    // Hash an input string and return the hash as
    // a 32 character hexadecimal string.
    static string getMd5Hash(string input)
    {
        if (input == "")
            return "";
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
            sBuilder.Append(data[i].ToString("x2"));
        return sBuilder.ToString();
    }
     
    static string generateDeviceUniqueIdentifier(bool oldBehavior)
    {
        string id = "";
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass contextClass = new AndroidJavaClass("android.content.Context");
        string TELEPHONY_SERVICE = contextClass.GetStatic<string>("TELEPHONY_SERVICE");
        AndroidJavaObject telephonyService = activity.Call<AndroidJavaObject>("getSystemService", TELEPHONY_SERVICE);
        bool noPermission = false;
        try
        {
            id = telephonyService.Call<string>("getDeviceId");
        }
        catch (Exception e) {
            noPermission = true;
        }
        if(id == null)
            id = "";
        // <= 4.5 : If there was a permission problem, we would not read Android ID
        // >= 4.6 : If we had permission, we would not read Android ID, even if null or "" was returned
        if((noPermission && !oldBehavior) || (!noPermission && id == "" && oldBehavior))
        {
            AndroidJavaClass settingsSecure = new AndroidJavaClass("android.provider.Settings$Secure");
            string ANDROID_ID = settingsSecure.GetStatic<string>("ANDROID_ID");
            AndroidJavaObject contentResolver = activity.Call<AndroidJavaObject>("getContentResolver");
            id = settingsSecure.CallStatic<string>("getString", contentResolver, ANDROID_ID);
            if(id == null)
                id = "";
        }
        if(id == "")
        {
            string mac = "00000000000000000000000000000000";
            try
            {
                StreamReader reader = new StreamReader("/sys/class/net/wlan0/address");
                mac = reader.ReadLine();
                reader.Close();
            }
            catch (Exception e) {}
            id = mac.Replace(":", "");
        }
        return getMd5Hash(id);
    }
     
