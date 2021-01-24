    // Define other methods and classes here
    class Book
    {
	    public ObjectId _id { get; set; }
    	public string Word { get; set; }
    }
	void Main()
	{
		var mongoConnectionString = @"mongodb://Topaz:p%40$$w0rd@localhost";
		var client = new MongoDB.Driver.MongoClient(mongoConnectionString);
		var db = client.GetDatabase("Test");
		var col = db.GetCollection<Book>("Books");
		var filter = Builders<Book>.Filter.Empty;
		var projection = Builders<Book>.Projection.Expression(m => m.Word);
		var options = new FindOptions<Book, String> { BatchSize = 256, Projection = projection };
		var results = new List<string>();
		using (var cursor = col.FindAsync(filter, options).Result)
		{
			while (cursor.MoveNextAsync().Result)
			{
				var batch = cursor.Current as IList<String>;
				results.AddRange(batch);
			}
		}
		results.ForEach(a => Console.WriteLine(a));	
	}
