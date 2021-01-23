    static void Main(string[] args)
    {
        Task t = MainAsync(args);
        t.Wait();
    }
    static async Task MainAsync(string[] args)
    {
        var client = new MongoClient("mongodb://localhost:27017/test");
        var db = client.GetDatabase("name");
        var coll = db.GetCollection<Book>("collName");}
  
