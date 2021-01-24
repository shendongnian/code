	public void TrySomething(int sec)
	{
	    var sw = Stopwatch.StartNew();
	    while (sw.Elapsed.TotalSeconds < (double)sec)
	    {
	         // do useful stuff
	    }
	}
