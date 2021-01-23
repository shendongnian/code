    public void GetData()
    {
        IList<BsonDocument> Pipeline =new List<BsonDocument>();
        ///UnWind Query
        BsonDocument _oUnWind = new BsonDocument("$unwind", "$notes");
        Pipeline.Add(_oUnWind);
        ///Match Query
        IMongoQuery query = Query.NE("notes.title", "Hello MongoDB");
        Pipeline.Add(new BsonDocument("$match", query as BsonDocument));
    
        ///Group BY 
        IList<BsonElement> groupBYElement=new List<BsonElement>();
        IList<BsonElement> _id = new List<BsonElement>();
        _id.Add(new BsonElement("name", "$name"));
        _id.Add(new BsonElement("_id", "$_id"));
        groupBYElement.Add(new BsonElement("_id", new BsonDocument(_id)));
        groupBYElement.Add(new BsonElement("notes",new BsonDocument("$push","$notes")));
        BsonDocument _groupBy = new BsonDocument("$group", new BsonDocument(groupBYElement));
        Pipeline.Add(_groupBy);
    
        ///Project
        IList<BsonElement> ProjectElement = new List<BsonElement>();
        ProjectElement.Add(new BsonElement("_id", 0));
        ProjectElement.Add(new BsonElement("name", "$_id.name"));
        ProjectElement.Add(new BsonElement("_Id", "$_id._id"));
        ProjectElement.Add(new BsonElement("notes", "$notes"));
        BsonDocument _Project = new BsonDocument("$project", new BsonDocument(ProjectElement));
        Pipeline.Add(_Project);
    
        AggregateArgs _oAggregateArgs=new AggregateArgs();
        _oAggregateArgs.Pipeline =Pipeline;
    
        ///Mongo Database
        MongoDatabase _oMongoDatabase = MognoContext.GetDataBase();
    
        ///Final
        IList<BsonDocument> Result = _oMongoDatabase.GetCollection<ToTest>("ToTest").Aggregate(_oAggregateArgs).ToList();
        IList<ToTest> FinalResult = new List<ToTest>();
        foreach (BsonDocument itrBsonDocument in Result)
        {
            ToTest _oToTest= BsonSerializer.Deserialize<ToTest>(itrBsonDocument);
            FinalResult.Add(_oToTest);
        }
    }
