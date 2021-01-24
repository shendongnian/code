    public class ReadBlock {
        private static int nextString;
        private static readonly string[] strings = {
            "ONE  ", "TWO  ", "THREE", "FOUR ",
            "FIVE ", "SIX  ", "SEVEN", "EIGHT"
        };
        public static async Task<byte[]> ReadParaBlock() {
            var id = Interlocked.Increment(ref nextString) - 1;
            var name = strings[id % strings.Length];
            try
            {
                await ReadWriteAdapter.Current.Semaphore.WaitAsync();
                Trace.WriteLine($"[{name.Trim()}] Entered Semaphore");
                await Write(Encoding.ASCII.GetBytes("TEST_" + name));
                return await Read();
            }
            finally {
                Trace.WriteLine($"[{name.Trim()}] Exiting Semaphore");
                ReadWriteAdapter.Current.Semaphore.Release();
            }
        }
        public static async Task<uint> Write(byte[] bytes) =>
            await ReadWriteAdapter.Current.WriteAsync(bytes);
        public static async Task<byte[]> Read() => await ReadWriteAdapter.Current.Listen(10);
    }
