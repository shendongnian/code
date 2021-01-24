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
    
        static void Main(string[] args)
        {
          for (int i = 1; i <= 15; ++i)
          {
            Task.Factory.StartNew((state) =>
            {
              int number = (int)state;
    
              PrintSomething(number);
              if (i % 5 == 0)
              {
                Thread.Sleep(2000);
              }
            }, i);
          }
          Console.ReadLine();
        }
    
        public static void PrintSomething(int number)
        {
          semaphore.WaitOne();
          try
          {
            Console.WriteLine("Thread: {0}, Number: {1}", Thread.CurrentThread.ManagedThreadId, number);
          }
          finally
          {
            semaphore.Release();
          }
        }
      }
    }
