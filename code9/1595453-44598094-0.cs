    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public class VoteCollection
        {
            public ObjectId Id;
            public string voteDocumentId;
            public VoteResult[] voteResultList;
        }
    
        public class VoteResult
        {
            public string voteId;
            public string voteResult;
        }
    
        public class Program
        {
            public static IMongoDatabase _db;
    
            static void Main(string[] args)
            {
                var collection = new MongoClient().GetDatabase("test").GetCollection<VoteCollection>("VoteCollection");
    
                collection.InsertOne
                (
                    new VoteCollection
                    {
                        voteDocumentId = "foo",
                        voteResultList = new []
                        {
                            new VoteResult { voteId = "bar1", voteResult = "NA" },
                            new VoteResult { voteId = "bar2", voteResult = "Against" },
                        }
                    }
                );
    
                var filter = Builders<VoteCollection>.Filter.Where(voteCollection => voteCollection.voteDocumentId == "foo" && voteCollection.voteResultList.Any(voteResult => voteResult.voteId == "bar1"));
                var update = Builders<VoteCollection>.Update.Set(voteCollection => voteCollection.voteResultList[-1].voteResult, "Approve");
                collection.UpdateMany(filter, update);
                
                Console.ReadLine();
            }
        }
    }
