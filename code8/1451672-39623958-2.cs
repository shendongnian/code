    public void DisplayTimeEvent(object source, ElapsedEventArgs e)
    {
        DateTime now = DateTime.Now;
        DateTime today3am = now.Date.AddHours(3);
        if (DateTime.Today == today3am.Date && now >= today3am)
        {
            Dispatcher.Invoke(() => btnMyButton.IsEnabled = true);
        }
    }
