    public class StringArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            for (int i = 0; i < array.Count; i++)
            {
                //If item is just a string, convert it string collection
                if (array[i].Type == JTokenType.String)
                {
                    array[i] = JToken.FromObject(new List<string> {array[i].ToObject<string>()});
                }
            }
            return array.ToObject<List<string[]>>();
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<string[]>));
        }
    }
    public class JsonObject
    {
        [JsonConverter(typeof(StringArrayConverter))]
        public List<string[]> booster { get; set; }
    }
