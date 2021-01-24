    private static DateTime lastRunAt;
    public static void LoadFromFile()
    {
        // loads Token value from a settings file
        lastRunAt = DateTime.UtcNow;
    }
    
    void Session_Start(object sender, EventArgs e)
    {
        if (DateTime.UtcNow.DayOfYear != lastRunAt.DayOfYear)
            LoadFromFile();
    }
