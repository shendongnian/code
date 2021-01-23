    public void Process10People()
    {
        for (var i = 1; i <= 10; i++)
        {
            new Thread(Enter).Start(i);
        }
    }
    private void Enter(object id)
    {
        Console.WriteLine(id + ". wants to enter");
        while (true)
        {
            lock(lockObject)
            {
                if (this.threadCount < MaxThreadsAllowed) // MaxThreadsAllowed = 2 in your case
                {
                     this.threadCount++;
                     break;
                }
            }
            // Thread.Sleep(100); // Add a sleep if you'd like
        }
        Console.WriteLine(id + ". is in!");
        Thread.Sleep(1000);
        Console.WriteLine(id + ". is done");
        lock(lockObject)
        {
            this.threadCount --;
        }
    }
