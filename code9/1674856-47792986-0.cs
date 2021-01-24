    public class WaitTester
    {
        public static bool _wait = false;
    
        public static void Initialize()
        {
            StartThreadOne(5);
            StartThreadTwo(5);
        }
    
        public static void StartThreadOne(int n)
        {
            new System.Threading.Tasks.Task(new Action<Object>((num) =>
                {
                    Console.WriteLine("Thread1: == Start ========");
                    int max = (int)num;
                    for (int i = 0; i <= max; i++)
                    {
                        while (_wait) { Thread.Sleep(100); }
                        Console.WriteLine("Thread1: Tick - {0}", i);
                        Thread.Sleep(1000);
                    }
                    Console.WriteLine("Thread1: == End =========");
                }), n).Start();
        }
    
        public static void StartThreadTwo(int n)
        {
            new System.Threading.Tasks.Task(new Action<Object>((num) =>
                {
                    Console.WriteLine("Thread2: == Start ========");
                    _wait = true;
                    int max = (int)num;
                    for (int i = 0; i <= max; i++)
                    {
                        Console.WriteLine("Thread2: Tick - {0}", i);
                        Thread.Sleep(1000);
                    }
                    _wait = false;
                    Console.WriteLine("Thread2: == End =========");
                }), n).Start();
        }
    }
