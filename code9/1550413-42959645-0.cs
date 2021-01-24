    private const int minutes = 3;
    private static bool active = true;
    
    public static void FetchData()
    {
        // Send your requests using HttpWebRequest / WebClient
    }
    
    public static async Task BeginTimer()
    {
        while (active)
        {
            await Task.Delay(minutes * 1000);
            FetchData();
        }
    }
    
    public static void StopTimer()
    {
        active = false;
    }
