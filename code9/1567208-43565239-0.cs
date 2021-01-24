    public static class JsonExtensions
    {
        public static IEnumerable<JToken> AsArray(this JToken item)
        {
            if (item is JArray)
                return (JArray)item;
            return new[] { item };
        }
    }
