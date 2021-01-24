    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public class UnifiedPost
        {
            public ObjectId Id { get; set; }
            public string[] Tags { get; set; }
            public char Site { get; set; }
            public int Score { get; set; }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                var collection = new MongoClient().GetDatabase("test").GetCollection<UnifiedPost>("test");
    
                collection.InsertOne(new UnifiedPost() { Site = 'X', Tags = new[] { "a" } });
                collection.InsertOne(new UnifiedPost() { Site = 'Y', Tags = new[] { "a", "b" } });
                collection.InsertOne(new UnifiedPost() { Site = 'Z', Tags = new[] { "a", "b", "c" } });
    
                // 1. first filter
                var tagsWeAreInterestedIn = new[] { "a", "b" };
                var tagsFilter = Builders<UnifiedPost>.Filter.All(up => up.Tags, tagsWeAreInterestedIn);
    
                // 2. second filter
                var sitesWeAreInterestedIn = new[] { 'X', 'Y' };
                var siteFilter = Builders<UnifiedPost>.Filter.In(up => up.Site, sitesWeAreInterestedIn);
    
                // 3. third filter: rating (would follow the exact same pattern as the sites filter so we skip that part)
    
                // search for combined filter
                var query = collection.Find(tagsFilter & siteFilter);
    
                // 4. paging (e.g. sorted by the Score property, 10 results per page, skipped to page 4)
                // please note: this example will not return any data with skip=3
                // because we do not insert enough test data - use skip(0) to get a result!
                query = query.SortBy(up => up.Score).Skip(3).Limit(10);
    
                var postsWithTagB = query.ToList();
    
                Console.ReadLine();
            }
        }
