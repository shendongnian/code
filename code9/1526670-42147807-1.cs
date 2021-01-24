        static void Main(string[] args)
        {            
            var chrObservable = CharEnumerable().ToObservable();
            var timer1 = Observable.Interval(TimeSpan.FromSeconds(3));
            var chrAtInterval = timer1.Zip(chrObservable, (ts,c) => c);
            var numberObservable = NumEnumerable().ToObservable();
            var timer2 = Observable.Interval(TimeSpan.FromSeconds(1));
            var numberAtInterval = timer2.Zip(numberObservable, (ts,n) => n);
            chrAtInterval.WithLatestFrom(numberAtInterval,(c, n) => new{c,n})
                   .Subscribe(pair => Console.WriteLine(pair.c + ":" + pair.n));
            
            Console.WriteLine("Waiting...");
            Console.ReadKey();
        }
        private static IEnumerable<int> NumEnumerable()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return i;
            }
        }
        private static IEnumerable<char> CharEnumerable()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return (char)(i + 65);
            }
        }
