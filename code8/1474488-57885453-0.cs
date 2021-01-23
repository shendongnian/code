        static BlockingCollection<string> messageQueue = new BlockingCollection<string>(new ConcurrentQueue<string>());
        static Task messagePrinterTask;
        private static void ConsoleWriteLine(string s)
        {
            messageQueue.Add(s);
        }
        private static void StartMessageQueuePrinter()
        {
            messagePrinterTask = Task.Run(() =>
            {
                try { while(true) Console.WriteLine(messageQueue.Take()); }
                catch (InvalidOperationException) { } //CompleteAdding called.
            });
        }
        private static void StopMessageQueuePrinter()
        {
            messageQueue.CompleteAdding();
            messagePrinterTask.Wait();
        }
