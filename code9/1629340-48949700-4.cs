    /// <summary>
    /// Producer that generates random byte blobs with specified size.
    /// </summary>
    public class Producer
    {
        private static Random random = new Random();
        /// <summary>
        /// Returns source block that produced byte arrays. 
        /// </summary>
        /// <param name="blobSize">Size of byte arrays.</param>
        /// <param name="count">Total count of blobs (if 0 then infinite).</param>
        /// <param name="boundedCapacity">Bounded capacity (throttling).</param>
        /// <param name="cancellationToken">Cancellation token (used to stop infinite loop).</param>
        /// <returns>Source block.</returns>
        public static ISourceBlock<byte[]> BlobsSourceBlock(int blobSize, int count, int boundedCapacity, CancellationToken cancellationToken)
        {
            // Creating engine with specified bounded capacity.
            var engine = new Engine().CreateEngine(count, boundedCapacity, cancellationToken);
            // Creating transform block that uses our driver as a source.
            var block = new TransformBlock<int, byte[]>(
                // Useful work.
                i => CreateBlob(blobSize),
                new ExecutionDataflowBlockOptions
                {
                    // Here you can specify your own throttling. 
                    BoundedCapacity = boundedCapacity,
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                });
            // Linking engine (and engine is already working at that time).
            engine.LinkTo(block, new DataflowLinkOptions { PropagateCompletion = true });
            return block;
        }
        /// <summary>
        /// Simple random byte[] generator.
        /// </summary>
        /// <param name="size">Array size.</param>
        /// <returns>byte[]</returns>
        private static byte[] CreateBlob(int size)
        {
            var buffer = new byte[size];
            random.NextBytes(buffer);
            return buffer;
        }
    }
