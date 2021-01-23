    public class Repository<T> where T : AggregateRoot<T>
    {
        private ConcurrentDictionary<ObjectId, T> cache 
            = new ConcurrentDictionary<ObjectId, T>();
        private IMongoCollection<T> collection;
        public Repository(string connectionString, string databaseName, string collectionName)
        {
            collection = new MongoClient(connectionString)
                .GetDatabase(databaseName)
                .GetCollection<T>(collectionName);
        }
        public T Find(ObjectId aggregateRootId)
        {
            return cache.GetOrAdd(
                key: aggregateRootId, 
                valueFactory: key => findById(key));
        }
        private T findById(ObjectId aggregateRootId)
        {
            return collection
                .Find(Builders<T>.Filter
                    .Eq(x => x.Id, aggregateRootId))
                .SingleOrDefault();
        }
        
        public void SaveChanges()
        {   
            var writeModels = generateWriteModels();
            collection.BulkWrite(writeModels);
        }        
        private IEnumerable<WriteModel<T>> generateWriteModels()
        {
            List<WriteModel<T>> writeModels = new List<WriteModel<T>>();
            foreach (var cached in cache)
            {
                if (cached.Value != null)
                {
                    if (cached.Value.UpdateDefinition != null)
                    {   
                        writeModels.Add(new UpdateOneModel<T>(
                            filter: Builders<T>.Filter.Eq(x => x.Id, cached.Value.Id),
                            update: cached.Value.UpdateDefinition){ IsUpsert = true });
                        cached.Value.UpdateDefinition = null;
                    }
                }
            }
            return writeModels;
        }
    }
