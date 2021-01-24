	var universityRepository  = JToken.Parse(jsonString)["response"]
		// Filter the integer value by selecting only objects
		.OfType<JObject>()
		// Deserialize each object to a RootObject
		.Select(o => o.ToObject<RootObject>())
		// Return in a List<RootObject>
		.ToList();
	
	var listOfUniversities = universityRepository
		.Select(u => u.Title)
		.ToList();
