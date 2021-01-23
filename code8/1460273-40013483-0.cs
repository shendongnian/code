    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Reactive.Subjects;
    using System.Reactive.Linq;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
    
          Subject<int> userBalanceObservable = new Subject<int>();
        userBalanceObservable.Buffer(TimeSpan.FromSeconds(2)) //get List of items
                         .Subscribe(sampleList => ProcessSamples(sampleList));
    
          int cont = 0;
        
          while (!Console.KeyAvailable)
            {
            userBalanceObservable.OnNext(cont);
            cont++;
            userBalanceObservable.OnNext(cont);
            cont++;
            Thread.Sleep(1000);
          }
    
        }
    
        private static void ProcessSamples(IList<int> sampleList)
        {
          Console.WriteLine("[{0}]", string.Join(", ", sampleList.ToArray()));
        }
    
      }
    }
