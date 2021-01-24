    class IgnoreEmptyItemsConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(List<T>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<T> list = new List<T>();
            JArray array = JArray.Load(reader);
            foreach (JObject obj in array.Children<JObject>())
            {
                if (obj.HasValues)
                {
                    list.Add(obj.ToObject<T>(serializer));
                }
            }
            return list;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
