    static void Example2()
    {
        Task antecedent = new Task(() =>
        {
            Console.WriteLine("Antecedent begun");
            Thread.Sleep(1000);
        });
        antecedent.Start();
        Task parent = new Task(() =>
        {
            Console.WriteLine("Parent begun");
            Thread.Sleep(500);
        });
        Task.Factory.ContinueWhenAll(new[] { antecedent }, _ =>
        {
            Thread.Sleep(2000);
            Console.WriteLine("parent status: {0}", parent.Status);
        }, TaskContinuationOptions.AttachedToParent);
        parent.Start();
        parent.Wait();
    }
