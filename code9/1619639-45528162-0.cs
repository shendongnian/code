    private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = dtStart.Subtract(DateTime.Now);
            if (ts.TotalSeconds <= -16)
            {
                timer1.Stop();
            }
        }
