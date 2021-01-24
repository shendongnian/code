    using System;
    using System.Threading;
    
    public class SurrealVolatileSynchronizer
    {
        public volatile bool v1 = false;
        public volatile bool v2 = false;
        public int state = 0;
    
        public void DoWork1(object b)
        {
            var barrier = (Barrier)b;
            barrier.SignalAndWait();
            Thread.Sleep(100);
            state = 1;
            v1 = true;
        }
    
        public void DoWork2(object b)
        {
            var barrier = (Barrier)b;
            barrier.SignalAndWait();
            Thread.Sleep(200);
            bool currentV2 = v2;
            Console.WriteLine("{0}", state);
        }
    
        public static void Main(string[] args)
        {
            var synchronizer = new SurrealVolatileSynchronizer();
            var thread1 = new Thread(synchronizer.DoWork1);
            var thread2 = new Thread(synchronizer.DoWork2);
            var barrier = new Barrier(3);
            thread1.Start(barrier);
            thread2.Start(barrier);
            barrier.SignalAndWait();
            thread1.Join();
            thread2.Join();
        }
    }
