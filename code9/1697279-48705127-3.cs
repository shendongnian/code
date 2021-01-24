    public class Superwatch : IDisposable
    {
        static Stopwatch Watch = new Stopwatch();
        static Superwatch()
        {
            Watch.Start();
        }
        TimeSpan Start;
        public Superwatch()
        {
            Start = Watch.Elapsed;
        }
        public void Dispose()
        {
            TimeSpan elapsed = Watch.Elapsed - Start;
            Console.WriteLine($"Time elapsed: {elapsed}");
        }
    } 
