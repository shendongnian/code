    bool isDone = false;
	while (!isDone)
	{
		try
		{
			// your action with Add-In here...
			isDone = true;
		}
		catch (System.Runtime.InteropServices.COMException exception)
		{
            // small delay
			Thread.Sleep(10);
		}
	}
