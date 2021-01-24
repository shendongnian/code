    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace SempahoreTest1
    {
      class Program
      {
        static Semaphore semaphore = new Semaphore(5, 5);
        static Random    random    = new Random();
    
        static void Main(string[] args)
        {
          Parallel.For(1, 16, PrintSomething);
    
          Console.ReadLine();
        }
    
        public static void PrintSomething(int number)
        {
          semaphore.WaitOne();
          try
          {
            Console.WriteLine("Thread: {0}, Number: {1}, Access granted", Thread.CurrentThread.ManagedThreadId, number);
            // sleep to simulate long running method
            Thread.Sleep(random.Next(1000, 5000));
          }
          finally
          {
            semaphore.Release();
            Console.WriteLine("Thread: {0}, Number: {1}, Semaphore released", Thread.CurrentThread.ManagedThreadId, number);
          }
        }
      }
    }
