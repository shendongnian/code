      string connectionString = "connection string";
      MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
      settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
      var mongoClient = new MongoClient(settings);
      var searchText = "foundtoo";
      var db = mongoClient.GetDatabase("dbname");
      var collection = db.GetCollection<MyObject>("collectionName");
      var mydata1 = new Mydata {Comment = "Thank you"};
      var mydata2 = new Mydata {Comment = "amazing post, let's see if this can be foundtoo"};
      var list = new List<Mydata> {mydata1, mydata2};
      Mydata[] mydatas = {mydata1,mydata2};
      collection.InsertOneAsync(new MyObject
                {
                    Id = Guid.NewGuid().ToString(),
                    TextField1 = "this will be found in search",
                    Comments = mydatas
    
                }).Wait();
       var filterResult = collection.Find(Builders<MyObject>.Filter.ElemMatch("Comments", Builders<Mydata>.Filter.Where(p=>p.Comment.ToLowerInvariant().Contains(searchText.ToLowerInvariant())))).ToList();
