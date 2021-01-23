   		public void InitTimer()
		{
			timer = new System.Timers.Timer();
			timer.Enabled = true;
			timer.Elapsed += timer_Tick;
			timer.Interval = 200;
		}
		
		public void timer_Tick(object sender, System.Timers.ElapsedEventArgs e) 
		{
			timer.Enabled = false;
			System.Threading.Interlocked.Increment(ref current);
			if (current == 0)
			{
				current = HumidityPercent;
			}
			else
			{
				previous = current;
				current = HumidityPercent;
				RateOfChange = (current-previous)/5;
				Thread.Sleep(200);
			}
			timer.Enabled = true;
		}
