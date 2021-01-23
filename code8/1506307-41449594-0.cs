    private void LoadTimer()
	   Timer timer = new Timer
       timer.Interval = 4000;
       timer.Enabled = true; 
       timer.Tick += new EventHandler(timer1_Tick);
       timer.Start(); 
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
       // do your boolean operation where
    }
