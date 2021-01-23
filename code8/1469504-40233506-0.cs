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
				DoWork();
            }
        }
