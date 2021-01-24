        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://192.168.1.50:27017");
            //# It's ok if the database doesn't yet exist.  It will be created upon first use
            var database = client.GetDatabase("test");
            //# It’s ok if the collection doesn’t yet exist. It will be created upon first use.
            string targetCollection = "testCollection";
            bool alreadyExists = database.ListCollections().ToList().Any(x => x.GetElement("name").Value.ToString() == targetCollection);
            if (!alreadyExists)
            {
                database.CreateCollection(targetCollection);
            }
            var collection = database.GetCollection<BsonDocument>(targetCollection);
            
        }
