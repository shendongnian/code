    public class Repository : IRepository<TestCollectionAggregateRoot>
    {
        private readonly IMongoCollection<TestCollection> _mongoCollection;
        public Repository(IMongoCollection<TestCollection> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }
        public async Task<bool> SaveAsync(TestCollectionAggregateRoot aggregate)
        {
            var changes = aggregate.Observer.Definition;
            var selector = aggregate.Selector.Definition;
            await _mongoCollection.UpdateOneAsync(selector, changes);
            return true;
        }
    }
