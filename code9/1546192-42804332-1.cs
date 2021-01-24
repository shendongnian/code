    private void Timer2_Tick(object sender, EventArgs e)
    {
    	if (panel1.Left == 0 || panel1.Top == 0)
    	{
    		timer2.Stop();
    	}
    	else
    		panel1.Location = new Point(panel1.Location.X - 5, panel1.Location.Y - 5);
    }
