    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace SO39543690
    {
      class Program
      {
        static Random _rnd = new Random();
    
        static void Proc()
        {
          Console.WriteLine("3. Processing...");
          Thread.Sleep(_rnd.Next(50, 200));
        }
    
        static void Main(string[] args)
        {
          Thread thread = new Thread(new ThreadStart(() =>
          {
            Console.WriteLine("1. Processing...");
            Thread.Sleep(_rnd.Next(50, 200));
          }));
          thread.Start();
    
          thread = new Thread(() =>
          {
            Console.WriteLine("2. Processing...");
            Thread.Sleep(_rnd.Next(50, 200));
          });
          thread.Start();
    
          thread = new Thread(Proc);
          thread.Start();
    
          thread = new Thread(delegate ()
          {
            Console.WriteLine("4. Processing...");
            Thread.Sleep(_rnd.Next(50, 200));
          });
          thread.Start();
    
          Action proc = () =>
          {
            Console.WriteLine("5. Processing...");
            Thread.Sleep(_rnd.Next(50, 200));
          };
          thread = new Thread(new ThreadStart(proc));
          thread.Start();
    
    
          Console.WriteLine("END");
          Console.ReadLine();
        }
      }
    }
