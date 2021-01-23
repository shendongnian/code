    using Newtonsoft.Json;
    // ..
	// POST api/values
	[HttpPost]
	public object Post([FromBody]string jsonString)
	{
		// add reference to Newtonsoft.Json
		//  using Newtonsoft.Json;
		// jsonString to myJsonObj
		var myJsonObj = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString);
		// value1 is myJsonObj[key1]
		var valueOfkey1 = myJsonObj["key1"];
		return myJsonObj;
	}
