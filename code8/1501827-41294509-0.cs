	public void DoStuff<T>(T param)
	{
		if (param is double)
			// Only runs if T is confirmed to be a double, so no chance for errors
			DoStuffWithDouble((double)param); 
	}
