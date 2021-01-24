    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reactive.Linq;
    namespace Anything
    {
        public class Program
        {
            public static void Main(string[] _)
            {
                var sw = Stopwatch.StartNew();
                Keys()
                    .ToObservable()
                    .Select(x => new
                    {
                        Value = x,
                        Seconds = sw.Elapsed.TotalSeconds
                    })
                    .Buffer(5, 1)
                    .Where(xs => xs.Last().Seconds - xs.First().Seconds <= 1.0)
                    .Subscribe(ks => Console.WriteLine($"More than five! {ks.Count}"));
            }
            public static IEnumerable<ConsoleKeyInfo> Keys()
            {
                while (true)
                {
                    yield return Console.ReadKey(true);
                }
            }
        }
    }
