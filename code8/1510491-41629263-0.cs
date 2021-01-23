    public class Movie
    {
    	public ObjectId Id { get; set; }
    	public string movie_name { get; set;}
    }
...
    var client = new MongoClient();
    var db = client.GetDatabase("test");
    var collection = db.GetCollection<BsonDocument>("metacorp");
    var movies = collection.Find(x=>x.movie_name == "Hemin").ToEnumerable();
