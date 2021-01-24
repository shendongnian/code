    class CustomIObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IObject).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            IObject target;
            if (jo["ID"].Type == JTokenType.Integer)
            {
                target = Activator.CreateInstance<A>();
            }
            else  // Guid
            {
                target = Activator.CreateInstance<B>();
            }
            serializer.Populate(jo.CreateReader(), target);
            return target;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
