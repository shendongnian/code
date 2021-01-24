    public class NextRunCalculator
    {
        public double CalculateTimeUntilNextRun()
        {
            List<int> processingMinutes = new List<int> { ServiceConstants.RunMinute5 };//this is a list of minutes during the hour you want the service to run
            int t = int.MaxValue;
            foreach (var processingMinute in processingMinutes)
            {
                var minutesRemaining = processingMinute - DateTime.Now.Minute;
                if (minutesRemaining <= 0)
                {
                    minutesRemaining = 60 + minutesRemaining;//change 60 to however often you want the timer to run
                }
                if (minutesRemaining < t)
                {
                    t = minutesRemaining;
                }
            }
            return TimeSpan.FromMinutes(t).TotalMilliseconds;
        }
    }
	private void Timer_Elapsed(object sender, ElapsedEventArgs e)
	{
		_timer.Stop();
		//do work
		_timer.Interval = _nextRunCalculator.CalculateTimeUntilNextRun();
		_timer.Start();
	}
 
