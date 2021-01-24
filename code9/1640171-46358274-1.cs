    using System;
    using System.Reactive.Linq;
    
    namespace Printing {
        class Program {
            static void Main(string[] args) {
                var source = Observable.Interval(TimeSpan.FromSeconds(1.2))
                    .Do(i => Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: new item: {i}"));
                var sampling = source.Throttle(TimeSpan.FromSeconds(1))
                    .Do(i => Console.WriteLine($"{DateTime.Now.ToShortTimeString()}:  {i}"));
    
                var subscription = sampling.Subscribe();
    
                Console.ReadLine();
    
                subscription.Dispose();
    
                Console.ReadLine();
            }
        }
    }
