	void Main()
	{
		_timer = new System.Timers.Timer(100);
		
		_timer.Elapsed += Timer_Elapsed;
		
		_timer.Start();
	}
	private void Timer_Elapsed(object sender, EventArgs e)
	{
		try
		{
			for (int i = 0; i < 15; i++)
			{
				Console.Write(i + " ");
				Thread.Sleep(10);
			}
			Console.WriteLine();
		}
		catch (Exception ex)
		{
			_timer.Stop();
			Console.WriteLine(ex.Message);
		}
		finally
		{
			_timer.Start();
		}
	}
	private System.Timers.Timer _timer;
