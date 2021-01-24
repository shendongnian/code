    // android code for that should look like :
    // wifiManager.getClass().getMethod("setWifiApEnabled", WifiConfiguration.class, boolean.class);
    // but in Unity C# you have to split this into few chunks:
    // 1. Get calling class :
    using ( AndroidJavaObject classObj = wifiManager.Call<AndroidJavaObject>("getClass") )
    {
        // classObj should contains your class object 
        // 2. call get WifiConfiguration class details :
        using ( AndroidJavaObject wifiConfiguration = new AndroidJavaObject("setWifiApEnabled") )
        {
            // 3. Fill that object :
            wifiConfiguration.Set("SSID", meSSID); // string
            wifiConfiguration.Set("preSharedKey", mePassword); // string
            // 4. Get WifiConfiguration class definition
            using (AndroidJavaObject wifiCfgClass = wifiConfiguration.Call<AndroidJavaObject>("getClass") )
            { 
                // 5. Get boolean definition
                using ( AndroidJavaObject booleanObj = new AndroidJavaObject("java.lang.Boolean") )
                {
                    using ( AndroidJavaObject booleanClass = booleanObj.Call<AndroidJavaObject>("getClass") )
                    // 6. Get method definition
                    using ( AndroidJavaObject methodObj = classObj.Call<AndroidJavaObject>("getMethod", "setWifiApEnabled", wifiCfgClass , booleanClass)
                    {
                        // 7. Call that method :)
                        methodObj.Call("invoke", wifiManager, wifiConfiguration, enabled);
                    }
                }
            }
        }
    }
