    public void completed(GridView grid,StackPanel stackpanel)
    {
        string congo = "";
        if (winner())
        {
            TimeSpan duration = (DateTime.UtcNow - timer).Duration();
            congo = string.Format("Time: {0}:{1}:{2}", duration.Hours, duration.Minutes, duration.Seconds);
            grid.IsEnabled = false;
            stackpanel.Visibility = Visibility.Visible;
        }
    }
