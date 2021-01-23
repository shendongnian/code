       i++;
    
       var ts = TimeSpan.FromSeconds(i);
       if (ts.Minutes < 1)
            {
             lblTime.Text = string.Format("{0} Seconds", ts.Seconds);
            }
       else
            {
             lblTime.Text = string.Format("{0} Minutes, {1} Seconds", ts.Minutes, ts.Seconds);
            }
