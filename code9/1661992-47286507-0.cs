    class Program
    {
        static void Main(string[] args)
        {
            ServiceA a = new ServiceA();
            ServiceB b = new ServiceB();
            ServiceC c = new ServiceC();
            int maxDelay = 3000;
            var sw = new Stopwatch();
            sw.Start();
            Task taskA = Task.Delay(maxDelay - a.ResponseTime).ContinueWith(x =>
              {
                  a.DoWork();
                  Console.WriteLine($"taskA ready for {sw.Elapsed}");
              });
            Task taskB = Task.Delay(maxDelay - b.ResponseTime).ContinueWith(x =>
              {
                  b.DoWork();
                  Console.WriteLine($"taskB ready for {sw.Elapsed}");
              });
            Task taskC = Task.Delay(maxDelay - c.ResponseTime).ContinueWith(x =>
            {
                c.DoWork();
                Console.WriteLine($"taskC ready for {sw.Elapsed}");
            });
            taskA.Wait();
            taskB.Wait();
            taskC.Wait();
            Console.WriteLine(sw.Elapsed);
        }
    }
    class ServiceA
    {
        public int ResponseTime { get => 500; }
        public void DoWork() => Thread.Sleep(500);
    }
    class ServiceB
    {
        public int ResponseTime { get => 1000; }
        public void DoWork() => Thread.Sleep(1000);
    }
    class ServiceC
    {
        public int ResponseTime { get => 3000; }
        public void DoWork() => Thread.Sleep(3000);
    }
