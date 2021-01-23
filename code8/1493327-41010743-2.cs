    public class JsonResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType &&
                   objectType.GetGenericTypeDefinition() == typeof(JsonResponse<>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JSON data into a JObject
            JObject obj = JObject.Load(reader);
            // Remove the problematic data property from the JObject
            JProperty dataProp = obj.Property("data");
            if (dataProp != null) dataProp.Remove();
            // Create a JsonResponse object and populate it with the 
            // well-behaved properties in the JObject (e.g. RetCode, RetMsg)
            object jsonResponse = Activator.CreateInstance(objectType);
            serializer.Populate(obj.CreateReader(), jsonResponse);
            try
            {
                // Now try to add the data property into the same response
                if (dataProp != null)
                {
                    JObject data = new JObject(dataProp);
                    serializer.Populate(data.CreateReader(), jsonResponse);
                }
            }
            catch { }  // if it doesn't work, eat the exception
            return jsonResponse;
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
