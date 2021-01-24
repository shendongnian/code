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
