    try
    {
        timer1.Enabled = false;
        //Set interval and tick-handler from designer
        pauseTimer.Enabled = false;
        pauseTimer.Enabled = true;
    }
    catch (Exception ex)
    {
        Logging.LogFatal("Scroll event capture error: ", ex);
    }
