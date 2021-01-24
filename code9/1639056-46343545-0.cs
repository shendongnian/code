	private void Timer_Elapsed(object sender, EventArgs e)
	{
		try
		{
			_timer.Stop();
			
			//some work
		}
		catch(Exception ex)
		{
		
		}
		finally
		{
			_timer.Start();
		}
	}
