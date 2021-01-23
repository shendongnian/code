	bool createdNew;
	_mutex = new Mutex(false, mutexId, out createdNew);
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
