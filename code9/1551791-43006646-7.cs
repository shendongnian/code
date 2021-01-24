    private static void Main()
    {
        // Start message queue with setting to NOT send any messages
        var messageQueue = new MessageQueue(0);
        var cancel = false;
        // First thread sends a message once per second
        var t1 = new Thread(() =>
        {
            var counter = 1;
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                messageQueue.AddMessage($"{DateTime.Now} - First Thread: message #{counter++}");
                if (cancel) break;
            }
        });
        // Second thread sends a message once every 2 seconds
        var t2 = new Thread(() =>
        {
            var counter = 1;
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                messageQueue.AddMessage($"{DateTime.Now} - Second Thread: message #{counter++}");
                if (cancel) break;
            }
        });
        t1.Start();
        t2.Start();
        int secondsToWait = 10;
        Console.WriteLine($"\nLetting message queue build for {secondsToWait} seconds...");
        // A little progress bar while we're waiting...
        Console.Write(new string((char)9617, secondsToWait));
        Console.SetCursorPosition(0, Console.CursorTop);
        while (secondsToWait > 0)
        {
            secondsToWait--;
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.Write((char)9619);
        }
        Console.WriteLine();
        // Set queue size down to 5
        messageQueue.MaxQueueSize = 5;
        // Cancel when user presses any key
        Console.ReadKey();
        cancel = true;
    }
