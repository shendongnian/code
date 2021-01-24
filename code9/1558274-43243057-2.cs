    public static void Run()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        Task1(cts);
        Task2(cts.Token);
    }
    
    private static void Task2(CancellationToken token)
    {
        Task.Factory.StartNew(() =>
        {
            int s = 3; // parameter i want to change to stop it
    
                        while (!token.IsCancellationRequested)
            {
                Console.Write(s + 1);
            }
        }, token);
    }
    
    private static void Task1(CancellationTokenSource cts)
    {
        Task.Factory.StartNew(() =>
        {
            int sd = 3;
    
            while (sd < 20)
            {
                Console.Write("peanuts");
                sd++; //this i can change cuz its like local to the task
            }
        }).ContinueWith(t => cts.Cancel());
    }
