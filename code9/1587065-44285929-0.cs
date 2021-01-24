	static readonly TimeSpan updateFrequency = TimeSpan.FromMilliseconds( 20 );
	void ThreadProc()
	{
		Stopwatch sw = Stopwatch.StartNew();
		while( true )
		{
			string val = GetRandomNumberAsString();
			if( sw.Elapsed < updateFrequency )
				continue;	// Too early to update
			sw.Restart();
			Application.Current.Dispatcher.BeginInvoke( () => { textField1.Text = val; } );
		}
	}
