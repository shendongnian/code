    class Program {
    	static void Main(string[] args) {
    		IMongoClient client = new MongoClient();
    		IMongoDatabase db = client.GetDatabase("db");
    		IMongoCollection < PlayerPoints > collection = db.GetCollection < PlayerPoints > ("collection");
    		var pipeline = collection.Aggregate()
    			.Project(p => new {
    				PlayerId = p.PlayerId, TotalPoints = p.SeasonalPoints.Skip(9).Take(2).Aggregate((s1, s2) => s1 + s2)
    			})
    			.SortByDescending(s => s.TotalPoints)
    			.Project(e => new {
    				e.PlayerId
    			});
    		var result = pipeline.ToListAsync();
    	}
    }
