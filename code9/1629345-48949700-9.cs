    /// <summary>
    /// Engine-class (like a car engine) that produced a lot count (or infinite) of actions.
    /// </summary>
    public class Engine
    {
        private BufferBlock<int> _bufferBlock;
        /// <summary>
        /// Creates source block that produced stub data.
        /// </summary>
        /// <param name="count">Count of actions. If count = 0 then it's infinite loop.</param>
        /// <param name="boundedCapacity">Bounded capacity (throttling).</param>
        /// <param name="cancellationToken">Cancellation token (used to stop infinite loop).</param>
        /// <returns>Source block that constantly produced 0-value.</returns>
        public ISourceBlock<int> CreateEngine(int count, int boundedCapacity, CancellationToken cancellationToken)
        {
            _bufferBlock = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = boundedCapacity });
            Task.Run(async () =>
            {
                var counter = 0;
                while (count == 0 || counter < count)
                {
                    await _bufferBlock.SendAsync(0);
                    if (cancellationToken.IsCancellationRequested)
                        return;
                    counter++;
                }
            }, cancellationToken).ContinueWith((task) =>
            {
                _bufferBlock.Complete();
            });
            return _bufferBlock;
        }
    }
