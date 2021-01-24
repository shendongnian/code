    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    
    namespace mongoT
    {
        public interface IProtein
        {
            ObjectId Id { get; set; }
            int Count { get; set; }
    
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            DateTime Date { get; set; }
        }
    
        public class Protein : IProtein
        {
            public ObjectId Id { get; set; }
            public int Count { get; set; }
            public DateTime Date { get; set; }
    
            public override string ToString()
            {
                return $"{nameof(Id)}: {Id}, {nameof(Count)}: {Count}, {nameof(Date)}: {Date}";
            }
        }
    
        class Program
        {
            private static string DB = "ProteinsDB";
            private static string COLLECTION = "Proteins";
    
            static void Main(string[] args)
            {
                var result = GetProteinForDay(DateTime.Now.Date);
                Console.WriteLine(result);
            }
    
            public static IProtein GetProteinForDay(DateTime day)
            {
                var client = new MongoClient();
                var db = client.GetDatabase(DB);
    
                var collection = db.GetCollection<Protein>(COLLECTION);
                var query = collection.Find(p => p.Date == day.Date);
    
                var protein = query.FirstOrDefault();
                return protein;
            }
        }
    }
