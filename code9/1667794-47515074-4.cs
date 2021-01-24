    [HttpPost]
    public override async Task<IActionResult> Post([FromBody] Person person)
    {
    	var jsonDoc = JsonConvert.SerializeObject(person.Hobbies);
    	person.HobbiesBson = BsonSerializer.Deserialize<BsonDocument>(jsonDoc);
    
    	jsonDoc = JsonConvert.SerializeObject(person.Collection);
    	person.CollectionBson = BsonSerializer.Deserialize<BsonArray>(jsonDoc);
    
    	//save
    }
