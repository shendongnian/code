    private void PrintValuesAtTime(object sender, EventArgs args)
    {
    	System.Timers.Timer timer = sender as System.Timers.Timer;
    	// only print values if there are enough values
    	if (counter < ListAIntervals.Count && counter < ListB.Count)
    	{
    		Console.WriteLine($"Value: {ListB[counter]}");
            // there needs to be enough intervals left to go one more time
    		if (counter < ListAIntervals.Count - 1 && counter < ListB.Count - 1) 
    		{
    			counter++;
    			timer.Interval = ListAIntervals[counter] * 1000; // to make it in msec
    		}
    		else
    		{
    			// stop the timer
    			timer.AutoReset = false;
    		}
    	}    	
    }
