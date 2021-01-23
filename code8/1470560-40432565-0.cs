    public class TestEntity
    {
        public int Id { get; set; }
        public TestEntity[] Value { get; set; }
    }
    class Program
    {
        static void Main()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("TestEntities");
            var collection = db.GetCollection<TestEntity>("Entities");
            collection.InsertOne(CreateTestEntity(1, CreateTestEntity(2, CreateTestEntity(3, CreateTestEntity(4)))));
            const int selctedId = 3;
            var update = Builders<TestEntity>.Update.AddToSet(x => x.Value, CreateTestEntity(9));
            var depth1 = Builders<TestEntity>.Filter.Eq(x => x.Id, selctedId);
            var depth2 = Builders<TestEntity>.Filter.Where(x => x.Value.Any(item => item.Id == selctedId));
            var depth3 = Builders<TestEntity>.Filter.Where(x => x.Value.Any(item => item.Value.Any(item2 => item2.Id == selctedId)));
            var filter = depth1 | depth2 | depth3;
            collection.UpdateMany(filter, update);
            // if you need update document on same depth that you match it in query (for example 3 as selctedId), 
            // you must make 2 query (bad approach, better way is change schema):
            //var testEntity = collection.FindSync(filter).First();
            //testEntity.Value[0].Value[0].Value = new[] {CreateTestEntity(9)}; //todo you must calculate depth what you need in C#
            //collection.ReplaceOne(filter, testEntity);
        }
        private static TestEntity CreateTestEntity(int id, params TestEntity[] values)
        {
            return new TestEntity { Id = id, Value = values };
        }
    }
