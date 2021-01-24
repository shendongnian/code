    int counter = 0;
    var tasks = new List<Task>();
    var arr = Enumerable.Range(0, 921600).ToArray();
    var locker = new Object();
    tasks.Add(Task.Factory.StartNew(() =>
    {
    	for (int i = 0; i < 921600 / 2; i++)
    	{
    		if (arr[i] > 240)
    			lock (locker)
    				counter++;
    	}
    }));
    tasks.Add(Task.Factory.StartNew(() =>
    {
    	for (int j = 921600 / 2; j < 921600; j++)
    	{
    		if (arr[j] > 240)
    			lock (locker)
    				counter++;
    	}
    }));
    Task.WaitAll(tasks.ToArray());
