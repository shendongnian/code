    public class ReadWriteAdapter {
        private static ReadWriteAdapter instance;
        public static ReadWriteAdapter Current
            => LazyInitializer.EnsureInitialized(
                ref instance,
                () => new ReadWriteAdapter());
        private readonly MemoryStream stream = new MemoryStream();
        public SemaphoreSlim Semaphore { get; } = new SemaphoreSlim(1, 1);
        public async Task<string> Init()
            => await Task.FromResult("found port");
        public async Task<byte[]> Listen(uint bufferLength) 
            => await ReadAsync(bufferLength);
        private async Task<byte[]> ReadAsync(uint readBufferLength) {
            await Task.CompletedTask;
            var returnArray = new byte[readBufferLength];
            await stream.ReadAsync(returnArray, 0, returnArray.Length);
            return returnArray;
        }
        public async Task<uint> WriteAsync(byte[] data) {
            stream.SetLength(stream.Capacity);
            stream.Position = 0;
            await Task.Delay(1);
            await stream.WriteAsync(data, 0, data.Length);
            stream.SetLength(data.Length);
            stream.Position = 0;
            return (uint)data.Length;
        }
    }
