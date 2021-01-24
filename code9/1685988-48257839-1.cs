    class CustomConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray rows = JArray.Load(reader);
            foreach (JArray row in rows.Children<JArray>())
            {
                foreach (JToken item in row.Children().ToList())
                {
                    if (item.Type != JTokenType.String)
                        item.Remove();
                }
            }
            return rows.ToObject<string[][]>(serializer);
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
