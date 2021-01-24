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
            Console.WriteLine("Thread: {3}, Expected: {0}, Actual: {1}, Diff: {2}", expected, actual, actual - expected, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
        }
    }
