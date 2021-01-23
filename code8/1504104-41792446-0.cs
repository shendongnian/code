    [SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class BenchTest
    {
        private bool firstCall;
        [Benchmark]
        public void FirstTimeInitEffect()
        {
            if (firstCall == false)
            {
                firstCall = true;
                Console.WriteLine("// First call");
                Thread.Sleep(1000);
            }
            else
                Thread.Sleep(10);
        }
    }
