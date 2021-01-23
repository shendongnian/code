	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var json = JToken.Load(reader);
		object relationship = CreateObject(json);
		if (relationship != null)
		{
			serializer.Populate(json.CreateReader(), relationship);
		}
		return relationship;
	}
	private object CreateObject(JToken token)
	{
		if (token.Type == JTokenType.Null)
		{
			return null;
		}
		if (token["data"] == null)
		{
			return new ToOneRelation();
		}
		switch (token["data"].Type)
		{
			case JTokenType.Null:
			case JTokenType.Object:
				return new ToOneRelation();
			case JTokenType.Array:
				return new ToManyRelation();
			default:
				throw new Exception("Incorrect json.");
		}
	}
