	public static class JsonExtensions
	{
		public static dynamic ToDynamic(this JToken token)
		{
			if (token == null)
				return null;
			else if (token is JObject)
				return token.ToObject<ExpandoObject>();
			else if (token is JArray)
				return token.ToObject<List<ExpandoObject>>().Cast<dynamic>().ToList();
			else if (token is JValue)
				return ((JValue)token).Value;
			else
				// JConstructor, JRaw
				throw new JsonSerializationException(string.Format("Token type not implemented: {0}", token));
		}
	}
