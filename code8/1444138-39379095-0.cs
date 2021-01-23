    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;
    
    namespace ConsoleApplication1
    {
        class Program
        {
           static MongoClient mongoClient = new MongoClient();
            static IMongoDatabase databaseBase = mongoClient.GetDatabase("dbTest", null);
            static IMongoCollection<A> collection = databaseBase.GetCollection<A>("tests", null);
            static void Main(string[] args)
            {
                 
                var a = new A
                {
                    _id = 1,
                    V1 = 0,
                    V2 = 0
                };
                
                Parallel.Invoke( ()=> { var res=UpdateV1(1, 10).Result; },  ()=> { var res =  UpdateV2(1, 20).Result; });
    
                
    
            }
            static async  Task<long> UpdateV1(int id, int V)
            {
                var F = Builders<A>.Filter.Eq(a => a._id, id);
                var U = Builders<A>.Update.Set(a => a.V1, V);
                var result = await collection.UpdateOneAsync(F, U);
                return result.ModifiedCount;  
            }
    
            static async Task<long> UpdateV2(int id, int V)
            {
                var F = Builders<A>.Filter.Eq(_ => _._id, id);
                var U = Builders<A>.Update.Set(_ => _.V2, V);
                var result = await collection.UpdateOneAsync(F, U);
                return result.ModifiedCount;
            }
    
    
        }
        class A
        {
           public  int _id;
           public   int V1;
           public  int V2;
        }
    }
