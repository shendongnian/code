    static void Consumer()
    {
		int item;
        while(!bc.IsCompleted)
        {
			item = bc.Take();
			Console.WriteLine("An item has been consumed: {0}", item);
			Thread.Sleep(20);
        }
    }
    static void Main(string[] args)
    {
        Task t1 =Task.Run(() => producer(valueP));
        Task t2 = Task.Run(() => producer(valueP));
        Task t3 = Task.Run(() => Consumer());
        Task.WaitAll(t1, t2);
        bc.CompleteAdding(); // signal end of producing values
        t3.Wait(); // wait for consumer to read any unread values
    }
