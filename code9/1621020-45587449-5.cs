    public class PagedResultsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(PagedResults<>);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            string dataPropertyName = "Results";
            if (type.GetGenericArguments().Any())
            {
                var genericType = type.GetGenericArguments()[0];
                dataPropertyName = genericType.Name;
            }
            JObject jo = new JObject();
            if (type.GetProperty("Results")?.GetValue(value) != null)
            {
                jo.Add(dataPropertyName, JArray.FromObject(type.GetProperty("Results")?.GetValue(value)));
            }else
            {
                jo.Add(dataPropertyName, null);
            }
            foreach (PropertyInfo prop in type.GetProperties().Where(p => !p.Name.StartsWith("Results")))
            {
                jo.Add(prop.Name, new JValue(prop.GetValue(value)));
            }
            jo.WriteTo(writer);
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
