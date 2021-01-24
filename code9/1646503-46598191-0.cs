    private void Form1_Load(object sender, EventArgs e)
    {
        myTimer = new System.Timers.Timer(5000);
        myTimer.Elapsed += myEvent;
        myTimer.AutoReset = true;
        myTimer.Enabled = true;
        
