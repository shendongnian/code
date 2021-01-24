    public class Program {
        public static void Main() {
            for (int j = 0; j < 10; j++)
            for (int i = 1; i < 10; i++) {
                TestDelay(i * 1000);
            }
            Console.ReadKey();
        }
        static async Task TestDelay(int expected) {
            var startTime = DateTime.Now;
            await Task.Delay(expected).ConfigureAwait(false);
            var actual = (int) (DateTime.Now - startTime).TotalMilliseconds;
            ThreadPool.GetAvailableThreads(out int aw, out _);
            ThreadPool.GetMaxThreads(out int mw, out _);            
            Console.WriteLine("Thread: {3}, Total threads in pool: {4}, Expected: {0}, Actual: {1}, Diff: {2}", expected, actual, actual - expected, Thread.CurrentThread.ManagedThreadId, mw - aw);
            Thread.Sleep(5000);
        }
    }
