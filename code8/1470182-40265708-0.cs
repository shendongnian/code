    public class CustomDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IDictionary dict = (IDictionary)value;
            JArray array = new JArray();
            foreach (DictionaryEntry kvp in dict)
            {
                JObject obj = new JObject();
                obj.Add(kvp.Key.ToString(), kvp.Value != null ? JToken.FromObject(kvp.Value, serializer) : new JValue((string)null));
                array.Add(obj);
            }
            array.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
