    class Program
    {
		public static void Main()
		{
			var blockingCollection = new QueuedBlockingCollection<int>(10);
			var tasks = new List<Task>();
			//Block the collection by filling it up
			for (int i=1; i<=10; i++) blockingCollection.Add(99);
			
			//Start 10 threads all trying to add another value
			for (int i=1; i<=10; i++)
			{
				int j = i; //remove from closure
				tasks.Add
				( 
					Task.Run( () => blockingCollection.Add(j) )
				);
			}
	
			//Read the collection one at a time, giving other threads a chance to backfill
			while (blockingCollection.Count > 0)
			{
				var n = blockingCollection.Take();
				System.Threading.Thread.Sleep(100);
				Console.WriteLine(n);
			}
			Task.WaitAll(tasks.ToArray());
		}
	}
