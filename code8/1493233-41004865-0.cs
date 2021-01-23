    private void CheckTime()
    {
    	clock.Text = DateTime.Now.ToString("hh:mm:ss");
    	date.Text = DateTime.Now.ToLongDateString();
    	DateTime alarm = this.dateTimePicker1.Value;
    	DateTime currentTime = DateTime.Now;
    	if (alarm.Hour == currentTime.Hour && alarm.Minute == currentTime.Minute)
    	{
    	   timer1.Enabled = false;
    	   MessageBox.Show("Alarm");
    
    	}
    }
