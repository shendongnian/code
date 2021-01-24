    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        public class MyClass
        {
            public ObjectId Id;
            public string Key;
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                IEnumerable<string> ids = new [] { "a", "b", "c" };
    
                var collection = new MongoClient().GetDatabase("test").GetCollection<MyClass>("test");
    
                foreach (var id in ids)
                {
                    collection.InsertOne(new MyClass { Key = id });
                }
                // here comes the "$in" query
                var filter = Builders<MyClass>.Filter.In(myClass => myClass.Key, ids);
    
                // sync
                List<MyClass> values = collection.Find(filter).ToList();
    
                // async
                var queryTask = collection.FindAsync(filter);
                values = GetValues(queryTask).Result;
    
                Console.ReadLine();
            }
    
            private static async Task<List<MyClass>> GetValues(System.Threading.Tasks.Task<IAsyncCursor<MyClass>> queryTask)
            {
                var cursor = await queryTask;
                return await cursor.ToListAsync<MyClass>();
            }
        }
    }
