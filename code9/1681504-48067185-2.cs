    public IMongoCollection<models.Login> GetLoginCollection()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("dbName");
        var collection = database.GetCollection<models.Login>("login");
    
        return collection;
    }
    
    public bool CheckLogin(models.Login log)
    {
        var collection = this.GetLoginCollection();
    
        var authSuccessful = collection
            .Count(login =>
                login.username == log.username &&
                login.password == log.password) > 0;
    
        return authSuccessful;
    }
