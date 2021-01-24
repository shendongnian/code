    class Program
    {
        static void Main(string[] args)
        {
            int[] ns = new int[4] { 100, 500, 1000, 5000 };
            int[] ks = new int[5] { 5, 10, 15, 80, 160 };
            int[] rs = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var inputs = ns
                .SelectMany(n => ks.Select(k => new { n, k }))
                .SelectMany(x => rs.Select(r => new { x.n, x.k, r }));
            var tasks = inputs.Select(x => Task.Run(() => RunProg(x.n, x.k, x.r)));
            var results = Task.WhenAll(tasks).Result;
        }
        static int RunProg(int n, int k, int r)
        {
            Thread.Sleep(1000);
            return n + k + r;
        }
    }
