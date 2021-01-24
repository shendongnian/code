    void Install()
    {
        try
        {
            GameObject.Find("TextDebug").GetComponent<Text>().text = "Installing...";
    
            //Get Unity Context
            AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");
    
    
            AndroidJavaClass plugin = new AndroidJavaClass("com.example.unitypluginappinstall.PluginClass");
            string result = plugin.CallStatic<string>("InstallApp", unityContext, savePath);
        }
        catch (Exception e)
        {
            GameObject.Find("TextDebug").GetComponent<Text>().text = e.Message;
        }
    }
