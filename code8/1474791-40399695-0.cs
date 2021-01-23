    class customBinder : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var type = Activator.CreateInstance(objectType);
            var data = JObject.Load(reader);
            var obj = JsonConvert.DeserializeObject(data.ToString(), type.GetType(), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            return obj;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
