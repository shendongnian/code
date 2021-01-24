    private class BlockingPartitioner<T> : Partitioner<T>
    {
        private readonly BlockingCollection<T> _Collection;
        private readonly CancellationToken _Token;
        public BlockingPartitioner(BlockingCollection<T> collection, CancellationToken token)
        {
            _Collection = collection;
            _Token = token;
        }
        public override IList<IEnumerator<T>> GetPartitions(int partitionCount)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<T> GetDynamicPartitions()
        {
            return _Collection.GetConsumingEnumerable(_Token);
        }
        public override bool SupportsDynamicPartitions
        {
            get { return true; }
        }
    }
