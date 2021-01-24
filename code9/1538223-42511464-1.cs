    class Program
    {
        static void Main(string[] args)
        {
            var runner = new SprocRunner(new DataAccess());
            var threads = new List<Task>();
            for (var i = 0; i < 150; i++)
            {
                threads.Add(runner.ExecuteSp($"Async {i}"));
            }
            Task.WaitAll(threads.ToArray());
        }
    }
    public class SprocRunner
    {
        private readonly System.Threading.SemaphoreSlim batcher = new System.Threading.SemaphoreSlim(10, 10);
        private readonly DataAccess da;
        public SprocRunner(DataAccess da)
        {
            this.da = da;
        }
        public async Task ExecuteSp(string asyncTaskName)
        {
            await batcher.WaitAsync();
            try
            {
                await this.da.ExecuteSP(asyncTaskName);
            }
            catch (Exception e)
            {
            }
            finally
            {
                batcher.Release();
            }
        }
    }
    public class DataAccess
    {
        public Task ExecuteSP(string name)
        {
            Console.WriteLine(name);
            return Task.Delay(5000);
        }
    }
