    public Task InsertUsers(IEnumerable<User> users)
    {
      // create client
      const string connectionString = "mongodb://localhost:27017";      
      var client = new MongoClient(connectionString);
    
      // get database
      var database = client.GetDatabase("myDb");
      
      // get user collection
      var collection = _database.GetCollection<User>("users");
      
      // insert users and return async Task
      return collection.InsertManyAsync(users);
    }
