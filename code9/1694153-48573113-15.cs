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
				tasks[index-1] = Task.Run( () => blockingCollection.Enqueue(index) );
				Task.Delay(100).Wait();  //Wait long enough for the Enqueue call to block
			}
	
			//Purge the collection, making room for more values
			while (blockingCollection.Count > 0)
			{
				var n = blockingCollection.Take();
				Console.WriteLine(n);
			}
			
			//Wait for our pending adds to complete
			Task.WaitAll(tasks);
			//Display the collection in the order read
			while (blockingCollection.Count > 0)
			{
				var n = blockingCollection.Take();
				Console.WriteLine(n);
			}
		}
	}
