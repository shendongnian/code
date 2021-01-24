	System.Timers.Timer timer = new System.Timers.Timer();
	// register the event which will be fired
	timer.Elapsed += PrintValuesAtTime;
	timer.Interval = 1; // an intervall of 0 is not allowed
	timer.AutoReset = true; // repeated execution of the timer
	timer.Start(); // start the timer
	
	Console.ReadLine();
