    private void myTimer_Tick(object sender, EventArgs e)
    {
        var green = (((float)System.Environment.TickCount / 300) % 2) != 0;
        SetColor( green ? Color.Green : Color.Empty);
    }
