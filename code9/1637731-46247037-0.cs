    protected override void OnStart(string[] args)
    {
        timer1 = new Timer();
        this.timer1.Interval = 2000; //every 2 seconds
        this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
        timer1.AutoReset = false;
        timer1.Enabled = true;
        Helper.ServiceStartLog("Test window service started");
    }
    private void timer1_Tick (object sender, ElapsedEventArgs e)
    {
        try
        {
            PDFHelper.WriteErrorLog("Timer ticker and Log Running Job is Running");
        }
        finally
        {
            //this gets run even if there was a exception.
            timer1.Start();
        }
    }
