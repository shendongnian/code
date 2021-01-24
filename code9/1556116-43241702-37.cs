    class Program
    {
        static void Main(string[] args)
        {
            var mongo = new MongoClient("mongodb://localhost:27017/test");
            var db = mongo.GetDatabase("test");
            db.DropCollection("students");
            db.CreateCollection("students");
            var collection = db.GetCollection<Student>("students");
            var today = DateTime.Now; //2017-04-05 15:21:23.234
            var yesterday = today.AddDays(-1);//2017-04-04 15:21:23.234
            // Create 2 documents (yesterday &  today)
            collection.InsertMany(new[]
                {
                new Student{Description = "today", CreatedOn = today},
                new Student{Description = "yesterday", CreatedOn = yesterday},
                }
             );
            var filterBuilder1 = Builders<Student>.Filter;
            var filter1 = filterBuilder1.Eq(x => x.CreatedOn, today);
            List<Student> searchResult1 = collection.Find(filter1).ToList();
            Console.Write(searchResult1.Count == 1);
            var filterBuilder2 = Builders<Student>.Filter;
            var filter2 = filterBuilder2.Eq(x => x.CreatedOn, yesterday);
            List<Student> searchResult2 = collection.Find(filter2).ToList();
            Console.Write(searchResult2.Count == 1);
        }
    }
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
    }
