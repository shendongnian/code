    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    namespace Anything
    {
        public class Program
        {
            public static void Main(string[] _)
            {
                Keys()
                    .ToObservable()
                    .Buffer(TimeSpan.FromSeconds(1))
                    .Where(ks => ks.Count >= 5)
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
