    class Program
    {
        static void Main(string[] args)
        {
            var tasks = Enumerable.Range(0, 1000000).Select(i =>
            {
                return Task.Run(() =>
                {
                    while (true) { }
                    return 0;
                });
            });
    
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }
    }
