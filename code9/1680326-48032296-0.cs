	public static bool CheckForSystemZoomEnabled()
	{
		#if UNITY_ANDROID
		try {
			using(AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");
				AndroidJavaObject objResolver = objActivity.Call<AndroidJavaObject>("getContentResolver");
				using(AndroidJavaClass clsSecure = new AndroidJavaClass("android.provider.Settings$Secure"))
				{
					int val = clsSecure.CallStatic<int>("getInt", objResolver, "accessibility_display_magnification_enabled");
					return val != 0;
				}
			}
		} catch(System.Exception) { }
		#endif
		return false;
	}
