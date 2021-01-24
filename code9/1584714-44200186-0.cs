                var client = new MongoClient();
            var db = client.GetDatabase("dblearnfiles");
            var coll = db.GetCollection<BsonDocument>("user");
            
            foreach(var item in coll.Find(new BsonDocument()).ToList())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
