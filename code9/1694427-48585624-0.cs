    public class ReadBlock {
        private static int nextString;
        private static readonly string[] strings = {
            "ONE", "TWO", "THREE", "FOUR",
            "FIVE", "SIX", "SEVEN", "EIGHT"
        };
        public static async Task<byte[]> ReadParaBlock() {
            try {
                await ReadWriteAdapter.Current.Semaphore.WaitAsync();
                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Entered Semaphore");
                await Write();
                return await Read();
            }
            finally {
                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Exiting Semaphore");
                ReadWriteAdapter.Current.Semaphore.Release();
            }
        }
        public static async Task<uint> Write() =>
            await ReadWriteAdapter.Current.WriteAsync(
                Encoding.ASCII.GetBytes(
                    "TEST_" + 
                    strings[(Interlocked.Increment(ref nextString) - 1) % strings.Length]));
        public static async Task<byte[]> Read() => await ReadWriteAdapter.Current.Listen(10);
    }
