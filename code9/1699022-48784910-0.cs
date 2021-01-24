    private class MyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IAddressPoint).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var address = (IAddressPoint)value;
            writer.WriteStartObject(); // {
            writer.WritePropertyName($"geo:{address.GetType().Name}"); // "geo:StreetAddress"
            // ... etc.
            writer.WriteEndObject(); // }
            // or you can just emit raw string:
            writer.WriteRaw(myJsonBody);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, 
        {
            // todo: and the deserialization part goes here
        }
    }
