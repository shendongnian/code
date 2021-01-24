     public MongoCursor<Form> GetFromDetails()
    {
        var DB = new Database();
        var collection = DB.GetCollection<Form>();
        var query = new QueryBuilder<Form>();
        var queryLst = new List<IMongoQuery>();
        var data = collection.FindAll().Where(x => x.Status == true && x.FormId == yourparameter).OrderByDescending(x => x.Version).First();
        DB.Dispose();
        return data;
    }
