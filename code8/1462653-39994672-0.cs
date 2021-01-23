      // <CAPS INSIDE> are wildcards
      var _client = new MongoClient(@"connection string");
      var _database = _client.GetDatabase("<DATABASE NAME>");
      var bre = new BsonRegularExpression("<YOUR REGEX PATTERN>");
      var copt = new ListCollectionsOptions{ Filter = 
        Builders<BsonDocument>.Filter.Regex ("name", bre )
      };
      var collectionsWithMatchingNames = _database.ListCollections(copt).ToList().Select (col => col["name"]); 
