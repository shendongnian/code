        ...
        var queue = new ConcurrentQueue<T>(); //Use your generic type for T
        var thread = new Thread(() => WorkOnQueue(queue));
    
        thread.IsBackground = true;
        thread.Name = "My Worker Thread";
        thread.Start();
        ...
   		private void WorkOnQueue(ConcurrentQueue queue)
        {	
            var pause = TimeSpan.FromSeconds(0.05);
			while (!abort) // some criteria to abort or even true works here
			{
				if (queue.Count == 0)
				{
					// no pending actions available. pause
					Thread.Sleep(pause);
					continue;
				}
				DoWork(); //Contains the TryDequeue ...
            }
        }
