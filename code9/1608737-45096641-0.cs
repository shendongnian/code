    public static class JsonExtensions
    {
        public static IEnumerable<JToken> SingleOrArrayItems(this JToken source)
        {
			if (source == null || source.Type == JTokenType.Null)
				return Enumerable.Empty<JToken>();
            IEnumerable<JToken> arr = source as JArray;
            return arr ?? new[] { source };
        }
	}
