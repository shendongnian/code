    public static class Program
    {
        public static void Main(params string[] args)
        {
            Lab lab = new Lab();
            List<BenchmarkReport> benchmarkReports = new List<BenchmarkReport>()
            {
                lab.RunNative(),
                lab.RunLambdaExpression(),
                lab.RunPropertyInfo()
            };
            foreach (var report in benchmarkReports)
            {
                Console.WriteLine("{0}: {1} ({2}ms) {3}",
                    report.Name.PadRight(20),
                    report.ElapsedTime,
                    report.ElapsedTime.TotalMilliseconds.ToString().PadLeft(10),
                    (double)report.ElapsedTime.TotalMilliseconds / report.Iterations);
            }
            Console.ReadKey();
        }
    }
