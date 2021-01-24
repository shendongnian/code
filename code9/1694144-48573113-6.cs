	public class Program
	{
		public static void Main()
		{
			//Setup
			var blockingCollection = new QueuedBlockingCollection<int>(10);
			var tasks = new Task[10];
			
			//Block the collection by filling it up
			for (int i=1; i<=10; i++) blockingCollection.Add(99);
			
			//Start 10 threads all trying to add another value
			for (int i=1; i<=10; i++)
			{
				int index = i; //unclose
				tasks[index-1] = Task.Run( () => blockingCollection.Add(index) );
			}
	
			//Read the collection one at a time, giving other threads a chance to backfill
			while (blockingCollection.Count > 0)
			{
				var n = blockingCollection.Take();
				Task.Delay(100).Wait();
				Console.WriteLine(n);
			}
			
			//Cleanup
			Task.WaitAll(tasks);
		}
	}
