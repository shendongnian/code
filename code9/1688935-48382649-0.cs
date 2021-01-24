    using System;
    using System.Linq;
    using System.Reactive.Linq;
    namespace Anything
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Observable
                    .Timer(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1))
                    .Select(x => new [] {"new value!"})
                    .StartWith(EnumerableEx.Return(new [] {"currently", "available", "values"}))
                    .Subscribe(x => Console.WriteLine(string.Join(",", x)));
                Console.ReadKey();
            }
        }
    }
