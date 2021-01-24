    [DataContract]
    [JsonConverter(typeof(NoContextConverter))]
    public class Thing
    {
        [DataMember(Name = "@context")]
        public string Context => "http://schema.org";
    }
    // ...............
    public class NoContextConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var props = value.GetType().GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(DataMemberAttribute)))
                .ToList();
            if (writer.Path != "")
                props.RemoveAll(p => p.Name == "Context");
            writer.WriteStartObject();
            foreach (var prop in props)
            {
                writer.WritePropertyName(prop.GetCustomAttribute<DataMemberAttribute>().Name);
                serializer.Serialize(writer, prop.GetValue(value, null));
            }
            writer.WriteEndObject();
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Thing).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
