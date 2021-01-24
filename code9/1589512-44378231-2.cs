    private static void Main(string[] args)
    {
        int level = 5;
        LevelEnum levelEnum = MyEnumeration.FromValue<LevelEnum>(level);
        levelDisplay.Text = levelEnum.DisplayName;
        timer = new Timer();
        timer.Interval = levelEnum.Interval;
        timer.Enabled = true;
        timer.Elapsed += levelEnum.Action;
        timer.Start();
    }
    internal static void Level1()
    {
        // Action for Level 1
    }
    internal static void Level2()
    {
        // Action for Level 2
    }
    internal static void Level3()
    {
        // Action for Level 3
    }
