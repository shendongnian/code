    class QueryEntryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(QueryEntry);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            QueryEntry entry = new QueryEntry();
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                serializer.Populate(token.CreateReader(), entry);
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (JToken child in token)
                {
                    entry.Group.Add(child.ToObject<QueryEntry>(serializer));
                }
            }
            return entry;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
