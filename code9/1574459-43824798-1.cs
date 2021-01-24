    public class JsonPathConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType,
                                        object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            object targetObj = Activator.CreateInstance(objectType);
            foreach (var prop in objectType.GetProperties()
                                           .Where(p => p.CanRead && p.CanWrite))
            {
                var att = prop.GetCustomAttributes(true)
                              .OfType<JsonPathAttribute>()
                              .FirstOrDefault();
                var jsonPath = (att != null ? att.JsonPath : prop.Name);
                var token = jo.SelectToken(jsonPath);
                if (token != null && token.Type != JTokenType.Null)
                {
                    var value = token.ToObject(prop.PropertyType, serializer);
                    prop.SetValue(targetObj, value, null);
                }
            }
            return targetObj;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // WriteJson is not called when CanWrite returns false
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when [JsonConverter] attribute is used
            return false;
        }
    }
