    using System;
    using System.Reactive.Linq;
    namespace Printing {
    class Program {
        static void Main(string[] args) {
            var source = Observable.Interval(TimeSpan.FromMilliseconds(333))
                .Do(i => Console.WriteLine($"new item: {i}"));
            var sampling = source.Throttle(TimeSpan.FromSeconds(1))
                .Do(i => Console.WriteLine($"sampled: {i}"));
            var subscription = sampling.Subscribe();
            Console.ReadLine();
            subscription.Dispose();
            Console.ReadLine();
        }
    }
