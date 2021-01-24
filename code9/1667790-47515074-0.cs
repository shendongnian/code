    // For the Hobbies object type:
    [BsonIgnore] //ignore this value in MongoDB
    public Dictionary<string, object> Hobbies { get; set; }
    
    [JsonIgnore] //ignore this value in the response on Get requests
    [BsonElement(elementName: "Hobbies")]
    public BsonDocument HobbiesBson { get; set; }
    /*********************************************************************/
    // For the Collection object type:
    [BsonIgnore] //ignore this value in MongoDB
    public List<Dictionary<string, object>> Collection { get; set; }
    
    [JsonIgnore] //ignore this value in the response on Get requests
    [BsonElement(elementName: "Collection")]
    public BsonArray CollectionBson { get; set; }
