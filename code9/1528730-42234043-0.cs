    abstract class EnqueueInfoProcessor<T>
        where T : EnqueueInfo
    {
        // here we will store all the messages received before the handling
        private readonly BufferBlock<T> _buffer;
        // simple action block for actual handling the items
        private ActionBlock<T> _action;
        // cancellation token to cancel the pipeline
        public EnqueueInfoProcessor(CancellationToken token)
        {
            _buffer = new BufferBlock<T>(new DataflowBlockOptions { CancellationToken = token });
            _action = new ActionBlock<T>(item => ProcessItem(item), new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount,
                CancellationToken = token
            });
            // we are linking two blocks so all the items from buffer
            // will flow down to action block in order they've been received
            _buffer.LinkTo(_action, new DataflowLinkOptions { PropagateCompletion = true });
        }
        public void PostItem(T item)
        {
            // synchronously wait for posting to complete
            _buffer.Post(item);
        }
        public async Task SendItemAsync(T item)
        {
            // asynchronously wait for message to be posted
            await _buffer.SendAsync(item);
        }
        // abstract method to implement
        protected abstract void ProcessItem(T item);
    }
