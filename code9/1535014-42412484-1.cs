    private DateTime _startTime;
    private int activeMinutes = 5;
    private int pauseMinutes = 2;
    private Timer _timer;
    private void StartTimer()
    {
        if(_timer != null)
        {
            // detach event handler from old timer before creating a new one
            _timer.Tick -= timer1_Tick;
        }
        _timer = new Timer();
        _timer.Interval = 12000;
        _timer.Tick += timer1_Tick;
        _timer.Start();
        _startTime = DateTime.Now;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {    
        TimeSpan elapsed = DateTime.Now.Subtract( _startTime );
        if( elapsed.Minutes < activeMinutes ||
           (elapsed.Minutes >= activeMinutes + pauseMinutes &&
            elapsed.Minutes % (activeMinutes + pauseMinutes) < activeMinutes))
        {
            circularProgressBar1.Increment(1);
            circularProgressBar1.Text = circularProgressBar1.Value.ToString();
            circularProgressBar1.SuperscriptText = "%";
        }
    }
