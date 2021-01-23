    using System;
    using System.Threading;
    public class Program
    {
        private static readonly object _lock = new object();
        public static void Main()
        {
            for (var i = 0; i <= 10; i++)
            {
                fn(i);
            }
            Console.ReadLine();
        }
    
        private static void fn(int i)
        {
            System.Threading.Thread thread = new System.Threading.Thread(() => ExecuteInBackground(i));
            thread.IsBackground = true;
            thread.Start();
        }
    
        private static void ExecuteInBackground(Object obj)
        {
            lock (_lock)
            {
                Thread.Sleep(500);
                Console.WriteLine("A "+obj);
                test.ttt(obj);
            }
        }
    }
    public static class test
    {
        //private static readonly object _lock = new object();
        public static void ttt(object obj)
        {
            //lock(_lock)
                Console.WriteLine("B "+ obj);
        }
    }
