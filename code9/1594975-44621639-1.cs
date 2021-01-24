    public class DynamicPropertyNameConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            JObject jo = new JObject();
            foreach (PropertyInfo prop in type.GetProperties().Where(p => p.CanRead))
            {
                string propName = prop.Name;
                object propValue = prop.GetValue(value, null);
                JToken token = (propValue != null) ? JToken.FromObject(propValue, serializer) : JValue.CreateNull();
                if (propValue != null && prop.PropertyType == typeof(object))
                {
                    JsonPropertyNameByTypeAttribute att = prop.GetCustomAttributes<JsonPropertyNameByTypeAttribute>()
                        .FirstOrDefault(a => a.ObjectType.IsAssignableFrom(propValue.GetType()));
                    if (att != null)
                        propName = att.PropertyName;
                }
                jo.Add(propName, token);
            }
            jo.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // ReadJson is not called if CanRead returns false.
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called if a [JsonConverter] attribute is used
            return false;
        }
    }
