    void OnTapped(object s)
    {
        if (LabelText == "START")
        {
            LabelText = "STOP";
            StartTimeText = DateTime.Now.ToString();
            hstopwatch.Restart();
        }
        else
        {
            LabelText = "START";
            StartTimeText = "Timer has been stopped";
            hstopwatch.Stop();
            hstopwatch.Reset();
        }
    }
