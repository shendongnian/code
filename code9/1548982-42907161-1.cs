    class Program {
        static Dictionary<string, ManualResetEvent> resetEvents = new Dictionary<string, ManualResetEvent>();
        static void Main()
        {
            for (int i = 0; i < 1000; i++) {
                new Thread(() =>
                {
                    resetEvents.Add(Guid.NewGuid().ToString(), new ManualResetEvent(false));
                })
                {
                    IsBackground = true
                }.Start();
            }
            Console.ReadKey();
        }      
    }
