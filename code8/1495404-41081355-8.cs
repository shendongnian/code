        static void Main(string[] args)
        {
            var timer1 = new Timer(_ => Console.WriteLine("Hello World"), null, 0, 2000);
            var timer2 = new Timer(_ => Console.WriteLine("Hello Stackoverflow"), null, 0, 4000);
            Thread.Sleep(TimeSpan.FromMinutes(1));
        }
