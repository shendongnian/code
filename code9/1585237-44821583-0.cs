     public class MongoRepository
    {
        const string DB_NAME = "dbname";
        public const string HOST = "serveradress";
        const string CONNECT_STRING = "connectionstring";
        private IMongoClient _client;
        private IMongoDatabase _db {
        
            get { return this._client.GetDatabase(DB_NAME); }
        }
        public MongoRepository()
        {
            _client = new MongoClient(CONNECT_STRING);
        }
        //Add a BSON document from a json string
        public void Add(string json, string collectionName)
        {
            var document = BsonSerializer.Deserialize<BsonDocument>(json);
            var collection = _db.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }
        //Add an item of the given type 
        public void Add<T>(T item) where T : class, new()
        {
            _db.GetCollection<T>(typeof(T).Name).InsertOne(item);
            
        }
        public async Task UpdateDocument<T>(ObjectId Id, T item )
        {
            var startTime = DateTime.UtcNow;
            try
            {
                var bsonWriter = new BsonDocumentWriter(new BsonDocument(), BsonDocumentWriterSettings.Defaults);
                BsonSerializer.Serialize<GlobalModel_Root>(bsonWriter, GlobalModel.rootGM);
                var doc = bsonWriter.Document;
                var collection = _db.GetCollection<BsonDocument>(typeof(T).Name);
                var filter = Builders<BsonDocument>.Filter.Eq("_id", Id);
                var entity = collection.Find(filter).FirstOrDefault();
                using (var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(60)))
                {
                    await collection.ReplaceOneAsync(filter, doc, null, timeoutCancellationTokenSource.Token);
                }
            }
            catch (OperationCanceledException ex)
            {
                var endTime = DateTime.UtcNow;
                var elapsed = endTime - startTime;
                Console.WriteLine("Operation was cancelled after {0} seconds.", elapsed.TotalSeconds);
            }   
        }
        public void Delete<T>(T item) where T : class, new()
        {
            //WorkAround for DeleteOne parameter
            ObjectFilterDefinition<T> filter = new ObjectFilterDefinition<T>(item);
            // Remove the object.
            _db.GetCollection<T>(typeof(T).Name).FindOneAndDelete(filter);
        }
    }
