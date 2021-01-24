	public void TrySomething(int sec)
	{
	    var sw = Stopwatch.StartNew();
	    while (true)
	    {
			var result = ...
	        // do useful stuff
			if (sw.Elapsed.TotalSeconds >= (double)sec)
			{
				return result;
			}
	    }
	}
