    public void DoStuff()
    {
        var intervalMs = 5000;
        var timer = new Timer(intervalMs);
        timer.Tick += new EventHandler(DoStuffOnTimer);
        timer.Enabled = true;
    }
    private void DoStuffOnTimer(object Sender, EventArgs e)
    {
        //do stuff
    }
