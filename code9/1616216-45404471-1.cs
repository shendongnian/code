    [JsonConverter(typeof(ObjectToArrayConverter<PoloniexPriceVolume>))]
    public class PoloniexPriceVolume
    {
        [JsonProperty(Order = 1)]
        public string Price { get; set; }
        [JsonProperty(Order = 2)]
        public double Volume { get; set; }
    }
    public class PoloniexPairInfo
    {
        public List<PoloniexPriceVolume> Asks { get; set; }
        public List<PoloniexPriceVolume> Bids { get; set; }
        [JsonConverter(typeof(BoolConverter))]
        public bool IsFrozen { get; set; }
        public int Seq { get; set; }
    }
    public class ObjectToArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }
        static bool ShouldSkip(JsonProperty property)
        {
            return property.Ignored || !property.Readable || !property.Writable;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var type = value.GetType();
            var contract = serializer.ContractResolver.ResolveContract(type) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException("invalid type " + type.FullName);
            var list = contract.Properties.Where(p => !ShouldSkip(p)).Select(p => p.ValueProvider.GetValue(value));
            serializer.Serialize(writer, list);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (token.Type != JTokenType.Array)
                throw new JsonSerializationException("token was not an array");
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException("invalid type " + objectType.FullName);
            var value = existingValue ?? contract.DefaultCreator();
            foreach (var pair in contract.Properties.Where(p => !ShouldSkip(p)).Zip(token, (p, v) => new { Value = v, Property = p }))
            {
                var propertyValue = pair.Value.ToObject(pair.Property.PropertyType, serializer);
                pair.Property.ValueProvider.SetValue(value, propertyValue);
            }
            return value;
        }
    }
    public class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? "1" : "0");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.Boolean)
                return (bool)token;
            return token.ToString() != "0";
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
