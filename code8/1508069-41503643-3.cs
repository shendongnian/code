	try
	{
		if (_mutex.WaitOne(timeOut, false))
		{
			//Process
            _mutex.RealeaseMutex();
		}
		else
		{
			//Handle not receiving the mutex
		}
	}
	catch (AbandonedMutexException)
	{
		//Handle
	}
