    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 2000  }; // here time in milliseconds
    private void button1_Click(object sender, EventArgs e)  // event handler of your button
    {
        button1.Click -= button1_Click; // remove the event handler for now
    
        label1.Text = "Speed reached!";
        // remove already attached tick handler if any, otherwise the handler would be called multiple times
        timer.Tick -= timer_Tick;
        timer.Tick += timer_Tick;
        timer.Start();
    }
    
    void timer_Tick(object sender, System.EventArgs e)
    {
        button1.Click += button1_Click; // attach the event handler again
        timer.Stop();
    }
