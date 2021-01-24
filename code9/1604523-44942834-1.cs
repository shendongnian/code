    // create it outside `Consumer` and make synchronized
    using (var taker = TextWriter.Synchronized(File.AppendText(@"pctaker.txt"))) {
        TaskCount = 3;
        Task.Factory.StartNew(() => Producer());
        //Producer();
        for (int i = 0; i < TaskCount; i++)
            // pass to consumer
            Task.Factory.StartNew(() => Consumer(taker));
        Console.ReadKey();
    }
    private static void Consumer(TextWriter writer)
    {
        int count = 1;
        foreach (var item in queue.GetConsumingEnumerable())
        {
            var message = string.Format("{3}.Item taken: {0} at {1} by thread {2}.", item, DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.ffffff"),
                    Thread.CurrentThread.ManagedThreadId, count);
            Console.WriteLine(message);                                
            writer.WriteLine(message);
            writer.Flush();
            count += 1;
        }
    }
