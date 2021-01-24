    public class StreamChunksResponse : IStreamWriterAsync
    {
        public IEnumerable<byte[]>> Chunks { get; set; }
        public async Task WriteToAsync(
            Stream responseStream, 
            CancellationToken token = default(CancellationToken))
        {
            foreach (var chunk in Chunks)
                responseStream.WriteAsync(chunk, 0, chunk.Length);
        }
    }
