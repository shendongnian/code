    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    namespace MongoAggregation
    {
    public class SeasonPoint
    {
        public int Season { get; set; }
        public int Point { get; set; }
    }
    public sealed class PlayerPoints
    {
        public ObjectId Id { get; set; }
        //Note that mongo addresses everything as UTC 0, so if you store local time zone values, make sure to use this attribute
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        public int Points { get; set; }
        //note that your model did not allow a player to not participate in some season, so I took the liberty of introducing a new sub document.
        //It is better to create sub documents that store metadata to simplify the query
        public ICollection<SeasonPoint> SeasonalPoints { get; set; }
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
            IMongoCollection<PlayerPoints> collection = db.GetCollection<PlayerPoints>(collectionName);
            IEnumerable<PlayerPoints> data = GetDummyData();
            collection.InsertMany(data);
            //some seasons to filter by
            var seasons = new[] {6, 7};
            
            //clear out unparticipating players from aggregated data to reduce computation overhead
            var seasonFilter = Builders<SeasonPoint>.Filter.In(season => season.Season, seasons);
            var playerFilter = Builders<PlayerPoints>.Filter.ElemMatch(point => point.SeasonalPoints, seasonFilter);
            //This shall remove all un-necessary seasons from aggregation pipeline
            var bsonFilter = new BsonDocument { new BsonElement("SeasonalPoints.Season", new BsonDocument("$in", new BsonArray(seasons))) };
            
            var groupBy = new BsonDocument// think of this as a grouping with an anonyous object declaration
            {
                 new BsonElement("_id", "$_id"),//This denotes the key by which to group - in this case the player's id, as we will be unwinding the players by the collection of season results, creating many entries per player.
                 new BsonElement("playerSum", new BsonDocument("$sum", "$SeasonalPoints.Point")),//We aggregate the player's points
                 new BsonElement("player", new BsonDocument("$first", "$$CURRENT")),// preserve player reference for projection stage
            };
            var sort = Builders<BsonDocument>.Sort.Descending(doc => doc["playerSum"]);
            List<BsonDocument> a = collection
                .Aggregate()
                .Match(playerFilter)
                .Unwind(x => x.SeasonalPoints)//this is where the magic happens
                .Match(bsonFilter)
                .Group(groupBy)
                .Sort(sort)
                .ToList();
            
    //All you need to do now is some simple projections to get the result back in the shape you want.
        }
        private static IEnumerable<PlayerPoints> GetDummyData()
        {
            return new[]
            {
                new PlayerPoints()
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new List<SeasonPoint>()
                    {
                        new SeasonPoint {Season = 1, Point = 100},
                        new SeasonPoint {Season = 2, Point = 100},
                        new SeasonPoint {Season = 3, Point = 100},
                        new SeasonPoint {Season = 4, Point = 100},
                        new SeasonPoint {Season = 5, Point = 100},
                        new SeasonPoint {Season = 6, Point = 100},
                        new SeasonPoint {Season = 7, Point = 100},
                    }
                },
                new PlayerPoints()
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new List<SeasonPoint>()
                    {
                        new SeasonPoint {Season = 1, Point = 100},
                        new SeasonPoint {Season = 2, Point = 100},
                        new SeasonPoint {Season = 3, Point = 100},
                        new SeasonPoint {Season = 4, Point = 100},
                        new SeasonPoint {Season = 5, Point = 100},
                        new SeasonPoint {Season = 6, Point = 150},
                        new SeasonPoint {Season = 7, Point = 100},
                    }
                },
                new PlayerPoints()
                {
                    CreateDate = DateTime.Today,
                    SeasonalPoints = new List<SeasonPoint>()
                    {
                        new SeasonPoint {Season = 1, Point = 100},
                        new SeasonPoint {Season = 2, Point = 100},
                        new SeasonPoint {Season = 3, Point = 100},
                        new SeasonPoint {Season = 4, Point = 100},
                        new SeasonPoint {Season = 5, Point = 100},
                        new SeasonPoint {Season = 6, Point = 0},
                        new SeasonPoint {Season = 7, Point = 300},
                    }
                },
            };
        }
    }
    }
