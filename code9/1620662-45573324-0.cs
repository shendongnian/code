    public class MyJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
            JObject jo = new JObject();
            
            foreach (PropertyInfo prop in value.GetType().GetProperties())
            {
                if (prop.CanRead)
                {
                    if (prop.PropertyType == typeof(Guid))
                        continue;
                    object propValue = prop.GetValue(value);
                    
                    if (propValue != null)
                    {
                        jo.Add(prop.Name, JToken.FromObject(propValue));
                    }
                }
            }
            jo.WriteTo(writer);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(objectType);
        }
    }
