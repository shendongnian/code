	var root = JToken.Parse(json);
	
	if (root is JContainer)
	{
		// If the root token is an array or object (not a primitive)
		var query = from obj in ((JContainer)root).Descendants().OfType<JObject>()	// Iterate through all JSON objects 
					let type = obj["type"] as JValue 								// get the value of the property "type"
					where type != null && type.Type == JTokenType.String 
						&& ((string)type).Contains(",") 							// If the value is a string that contains a comma
					select obj;														// Select the object
		foreach (var obj in query.ToList())
		{
			// Remove the selected object
			obj.Remove();
		}
	}
