    class Program
    {
        static void Main(string[] args)
        {
            var task1 = Task.Run(() => Func1());
            var task2 = Task.Run(() => Func2());
            Task.WaitAll(task1, task2);
        }
        static object lockObj = new object();
        static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Func3("Func1");
                Thread.Sleep(1);
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 10; i++)
            {
                Func3("Func2");
                Thread.Sleep(1);
            }
        }
        static void Func3(string fromFn)
        {
            lock(lockObj)
            {
                Console.WriteLine("Called from " + fromFn);
            }
        }
    }
