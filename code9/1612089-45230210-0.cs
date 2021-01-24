	public static void SetBool(string key, bool state)
    {
         PlayerPrefs.SetInt(key, state ? 1 : 0);
    }
 
    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);
        return value == 1 ? true : false;
    }
    void DownloadImage() {
        var isDownloaded = GetBool("IsImageDownloaded"); // <-- Check this first!
        if(!isDownloaded) {
           DownloadImageInternal(); // The real function to download an image
           SetBool("IsImageDownloaded", true);
        }
    }
