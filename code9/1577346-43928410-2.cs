    class MyTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            MyType mt = (MyType)value;
            JObject jo = new JObject();
            if (!string.IsNullOrWhiteSpace(mt.JsonData))
            {
                // JsonData is assumed to contain pre-formatted, comma-separated, JSON properties
                jo.Add(JObject.Parse("{" + mt.JsonData + "}").Properties());
            }
            foreach (PropertyInfo prop in typeof(MyType).GetProperties()
                     .Where(p => p.CanRead && p.Name != "JsonData"))
            {
                object val = prop.GetValue(mt, null);
                jo.Add(prop.Name, val != null ? JToken.FromObject(val, serializer) : JValue.CreateNull());
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
