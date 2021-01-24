    private readonly Lazy<Entities.Queue> _queue;
    public async Task<int> EnqueueAsync(DateTime timeRangeStartsOn, DateTime timeRangeEndsOn, IEnumerable<byte[]> bodies, CancellationToken cancellationToken)
    {
        const int nothingEnqueued = 0;
    
        using (var context = new MessageQueueContext(_connectionString, _schema))
        {
            context.Queues.Add(_queue.Value);
            context.Entry(_queue.Value).State = EntityState.Unchanged;
