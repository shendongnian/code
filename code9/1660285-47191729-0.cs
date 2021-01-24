    static void Main(string[] args) {
        var tasks = new Task[n];
        for (int j1 = 0; j1 < n; ++j1)
            tasks[j1] = Task.Factory.StartNew(() => doStuff());
    
        Task.WaitAll(tasks);
                Console.WriteLine("Done !");
    }
