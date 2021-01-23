    class Program
    {
        const int MAX_VALUE = 20;
        const int valueP = 0;
        static BlockingCollection<int> bc = new BlockingCollection<int>(new ConcurrentQueue<int>(), 20);
        static void producer(int value)
        {
            for (int i = 0; i < MAX_VALUE; i++)
            {
                bc.Add(value);
                value++;
                Console.WriteLine("Producing value {0}", value);
                Thread.Sleep(20);
            }
            Thread.Sleep(20);
        }
		
        static void Consumer()
        {
			foreach(var item in bc.GetConsumingEnumerable())
			{
				Console.WriteLine("An item has been consumed: {0}", item);
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
    }
