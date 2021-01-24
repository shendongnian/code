    private DateTime showOnDate = DateTime.Today;
    private void timer1_Tick(object sender, EventArgs e)
    {
        label1.Text = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss tt");
    	if (DateTime.Now.Hour == 18 && DateTime.Now.Minute == 24 && showOnDate == DateTime.Today)
    	{
    		showOnDate = DateTime.Today.AddDays(1);
    		MessageBox.Show("You have to submit a report");
    	}
    }
