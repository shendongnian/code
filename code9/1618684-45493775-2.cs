    var interval = TimeSpan.FromMinutes( 1 );
    var timer = new System.Timers.Timer( interval.TotalMilliseconds ) { AutoReset = false };
    timer.Elapsed += ( sender, eventArgs ) =>
    {
    	var start = DateTime.Now;
    	try
    	{
    		// do work
    	}
    	finally
    	{
    		var elapsed = DateTime.Now - start;
    		if ( elapsed < interval )
    			timer.Interval = (interval - elapsed).TotalMilliseconds;
    		else
    			timer.Interval = TimeSpan.FromSeconds( 30 ).TotalMilliseconds;
    		timer.Start();
    	}
    };
    timer.Start();
