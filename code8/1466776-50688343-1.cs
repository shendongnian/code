    private static string GetAndroidExternalFilesDir()
    {
         using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
         {
              using (AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
              {
                   // Get all available external file directories (emulated and sdCards)
                   AndroidJavaObject[] externalFilesDirectories = context.Call<AndroidJavaObject[]>("getExternalFilesDirs", null);
                   AndroidJavaObject emulated = null;
                   AndroidJavaObject sdCard = null;
                   for (int i = 0; i < externalFilesDirectories.Length; i++)
                   {
                        AndroidJavaObject directory = externalFilesDirectories[i];
                        using (AndroidJavaClass environment = new AndroidJavaClass("android.os.Environment"))
                        {
                            // Check which one is the emulated and which the sdCard.
                            bool isRemovable = environment.CallStatic<bool ("isExternalStorageRemovable", directory);
                            bool isEmulated = environment.CallStatic<bool> ("isExternalStorageEmulated", directory);
                            if (isEmulated)
                                emulated = directory;
                            else if (isRemovable && isEmulated == false)
                                sdCard = directory;
                        }
                   }
                   // Return the sdCard if available
                   if (sdCard != null)
                        return sdCard.Call<string>("getAbsolutePath");
                   else
                        return emulated.Call<string>("getAbsolutePath");
                }
          }
    }
