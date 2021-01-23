    public class CustomDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, AbstractDataObject>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dict = new Dictionary<string, AbstractDataObject>();
            JObject jo = JObject.Load(reader);
            foreach (JProperty prop in jo.Properties())
            {
                switch (prop.Name)
                {
                    case "SomeClass1":
                        dict.Add("SomeClass1", prop.Value.ToObject<SomeClass1>(serializer));
                        break;
                    case "SomeClass2":
                        dict.Add("SomeClass2", prop.Value.ToObject<SomeClass2>(serializer));
                        break;
                }
            }
            return dict;
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
