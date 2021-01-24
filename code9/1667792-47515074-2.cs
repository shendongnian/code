    [HttpGet("{id?}")]
    public override async Task<IActionResult> Get(string id = null)
    {
    	var people = //get data from mongoDB
    	foreach (var person in people)
    	{
    		var bsonDoc = BsonExtensionMethods.ToJson(person.HobbiesBson);
    		person.Hobbies = JsonConvert.DeserializeObject<Dictionary<string, object>>(bsonDoc);
    
    		bsonDoc = BsonExtensionMethods.ToJson(person.CollectionBson);
    		person.Collection = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(bsonDoc);bsonDoc);
    	}
    	return Ok(people);
    }
