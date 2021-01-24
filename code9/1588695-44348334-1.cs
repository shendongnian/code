    bool isMusicPlaying()
    {
        const string AUDIO_SERVICE = "audio";
        AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");
    
        bool mIsPlaying;
        using (AndroidJavaObject audioManager = unityContext.Call<AndroidJavaObject>("getSystemService", AUDIO_SERVICE))
        {
            mIsPlaying = audioManager.Call<bool>("isMusicActive");
        }
        return mIsPlaying;
    }
