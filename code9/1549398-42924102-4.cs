    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    namespace MongoAggregation
    {
    public sealed class PlayerPoints
    {
        public ObjectId Id { get; set; }
        //Note that mongo addresses everything as UTC 0, so if you store local time zone values, make sure to use this attribute
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        public int Points { get; set; }
        //note that your model did not allow a player to not participate in some season, so I took the liberty of introducing a new sub document.
        //It is better to create sub documents that store metadata to easo the query
        public int[] SeasonalPoints { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //used v 2.4.3 of C# driver and v 3.4.1 of the db engine for this example
            var client = new MongoClient();
            IMongoDatabase db = client.GetDatabase("agg_example");
            var collectionName = "points";
            db.DropCollection(collectionName);
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>(collectionName);
            IEnumerable<BsonDocument> data = GetDummyData().Select(d=>d.ToBsonDocument());
            collection.InsertMany(data);
            //some seasons to filter by - note transformation to zero based
            var seasons = new[] {6, 7};
            //This is the query body:
            var seasonIndex = seasons.Select(i => i - 1);
         
            //This shall remove all un-necessary seasons from aggregation pipeline
            var bsonFilter = new BsonDocument { new BsonElement("Season", new BsonDocument("$in", new BsonArray(seasonIndex))) };
            var groupBy = new BsonDocument// think of this as a grouping with an anonyous object declaration
            {
                 new BsonElement("_id", "$_id"),//This denotes the key by which to group - in this case the player's id
                 new BsonElement("playerSum", new BsonDocument("$sum", "$SeasonalPoints")),//We aggregate the player's points
                 new BsonElement("player", new BsonDocument("$first", "$$CURRENT")),// preserve player reference for projection stage
            };
            var sort = Builders<BsonDocument>.Sort.Descending(doc => doc["playerSum"]);
            var unwindOptions = new AggregateUnwindOptions<BsonDocument>
            {
                IncludeArrayIndex = new StringFieldDefinition<BsonDocument>("Season")
            };
            var projection = Builders<BsonDocument>.Projection.Expression((doc => doc["player"]));
            List<BsonValue> sorted = collection
                .Aggregate()
                .Unwind(x=>x["SeasonalPoints"], unwindOptions)
                .Match(bsonFilter)
                .Group(groupBy)
                .Sort(sort)
                .Project(projection)
                .ToList();
        }
        private static IEnumerable<PlayerPoints> GetDummyData()
        {
            return new[]
            {
                new PlayerPoints
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = Enumerable.Repeat(100,7).ToArray()
                },
                new PlayerPoints
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new []
                    {
                        100,100,100,100,100,150,100
                    }
                },
                new PlayerPoints
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new []
                    {
                        100,100,100,100,100,0,300
                    }
                },
            };
        }
    }
    }
