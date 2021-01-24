    // I've used Tuple<string, int, int> to store three values
    // you may want to change it to a custom class  
    private static Dictionary<int, Tuple<string, int, int>> s_Levels = 
      new Dictionary<int, Tuple<string, int, int>>() {
        {1, new Tuple<string, int, int>("LEVEL 1", 2000, Level1)},
        {2, new Tuple<string, int, int>("LEVEL 2", 2000, Level2)},
    };
    
    ...
    
    levelDisplay.Text = s_Levels[level].Item1;
    timer = new Timer();
    timer.Interval = s_Levels[level].Item2; /// DIFFERENT
    timer.Enabled = true;
    timer.Elapsed += s_Levels[level].Item3; /// DIFFERENT
    imer.Start();
