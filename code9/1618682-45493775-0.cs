    var interval = TimeSpan.FromMinutes(1).TotalMilliseconds;
    var Timer = new Timer( interval ) { AutoReset = false };
			Timer.Elapsed += ( sender, eventArgs ) =>
			{
				try
				{
                    // do work
                }
				finally
				{
					Timer.Start();
				}
			};
    Timer.Start();
