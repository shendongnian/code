    class NameValueConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the array of name-value pairs and transform into a JObject.
            // We are assuming all the names will be distinct.
            JObject obj = new JObject(
                JArray.Load(reader)
                      .Children<JObject>()
                      .Select(jo => new JProperty((string)jo["Name"], jo["Value"]))
            );
            // Instantiate the target object and populate it from the JObject.
            object result = Activator.CreateInstance(objectType);
            serializer.Populate(obj.CreateReader(), result);
            return result;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // WriteJson is not called when CanWrite returns false
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            // We only want this converter to handle classes that are expressly
            // marked with a [JsonConverter] attribute, so return false here.
            // (CanConvert is not called when [JsonConverter] attribute is used.)
            return false;
        }
    }
