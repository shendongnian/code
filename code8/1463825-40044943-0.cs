    internal class JsonArray : JsonValue
    {
        public List<JValue> Values;
        public override string ToString()
        {
            return string.Join(", ", Values ?? Enumerable.Empty<JValue>());
        }
    }
    internal class JsonObject : JsonValue
    {
        public Dictionary<string, JValue> Values;
        public override string ToString()
        {
            if (Values == null || Values.Count <= 0)
            {
                return "";
            }
            var builder = new StringBuilder();
            foreach (var item in Values)
            {
                builder
                    .AppendFormat("{0}: {1}", item.Key, item.Value)
                    .AppendLine();
            }
            return builder.ToString();
        }
    }
