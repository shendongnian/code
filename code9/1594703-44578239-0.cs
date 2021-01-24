    public class UserProfiles
    {
        public ObjectId Id;
        public bool FirstBillRequestSent;
    }
    
    public class Program
    {
        public static IMongoDatabase _db;
    
        public static async Task ProcessFirstTimeBillers()
        {
            var userProfiles = _db.GetCollection<UserProfiles>("UserProfiles");
    
            var builder = Builders<UserProfiles>.Filter;
            var filter = builder.Eq(x => x.FirstBillRequestSent, false);
    
            using (var cursor = userProfiles.Find(filter).ToCursor())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var doc in cursor.Current)
                    {
                        var jsonDoc = doc.ToJson();
                        var s = jsonDoc.ToString();
                        Console.WriteLine(s);
                        // prints something like:
                        // { "_id" : ObjectId("5944439d82d2e7265c86d50c"), "FirstBillRequestSent" : false }
                        // { "_id" : ObjectId("5944439d82d2e7265c86d50d"), "FirstBillRequestSent" : false }
                        // { "_id" : ObjectId("5944442b82d2e718d827d5d6"), "FirstBillRequestSent" : false }
                    }
                }
            }
        }
    
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient();
            _db = client.GetDatabase("test");
    
            var collection = _db.GetCollection<UserProfiles>("UserProfiles");
    
            collection.InsertOne(new UserProfiles { FirstBillRequestSent = true });
            collection.InsertOne(new UserProfiles { FirstBillRequestSent = true });
            collection.InsertOne(new UserProfiles { FirstBillRequestSent = true });
            collection.InsertOne(new UserProfiles { FirstBillRequestSent = false });
            collection.InsertOne(new UserProfiles { FirstBillRequestSent = false });
            collection.InsertOne(new UserProfiles { FirstBillRequestSent = false });
            ProcessFirstTimeBillers().Wait();
            Console.ReadLine();
        }
    }
