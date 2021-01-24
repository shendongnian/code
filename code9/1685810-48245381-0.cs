    class CustomArrayConverter<T> : JsonConverter
    {
        string PropertyName { get; set; }
        public CustomArrayConverter(string propertyName)
        {
            PropertyName = propertyName;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = new JArray(JArray.Load(reader).Select(jo => jo[PropertyName]));
            return array.ToObject(objectType, serializer);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IEnumerable<T> items = (IEnumerable<T>)value;
            JArray array = new JArray(
                items.Select(i => new JObject(
                    new JProperty(PropertyName, JToken.FromObject(i, serializer)))
                )
            );
            array.WriteTo(writer);
        }
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when the [JsonConverter] attribute is used
            return false;
        }
    }
