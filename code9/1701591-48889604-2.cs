    public class helper
	{
		Timer timer = new Timer();
		private int counter = 0;
		private int returnCode = 0;
		public event EventHandler<int> Done;
		...
		private void OnTimedEvent(Object source, ElapsedEventArgs e, int optionalWay)
		{
			counter++;
			Console.WriteLine("Timer is ticking");
			if (counter == 10)
			{
				timer.Stop();
				timer.Dispose();
				returnCode = returnCode + 1;
				if (Done != null)
				{
					Done.Invoke(this, returnCode);
				}
			}
		}
	}
