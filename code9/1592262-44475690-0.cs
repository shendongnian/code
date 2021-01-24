     class Program
        {
            private delegate void del();
            static void Main(string[] args)
            {
                del d = updateConsole;
                var res = d.BeginInvoke(null, null);
                while (!res.IsCompleted)
                {
                    // do the job here
                }
                d.EndInvoke(res);
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Done!");
                Console.Read();
            }
    
            private static void updateConsole()
            {
                for (var i = 0; i <= 10; i++)
                {
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine(i);
                }
    
            }
        }
