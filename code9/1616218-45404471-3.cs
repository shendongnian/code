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
        //https://stackoverflow.com/a/39462464/3744182
        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("invalid type {0}.", objectType.FullName));
            writer.WriteStartArray();
            foreach (var property in SerializableProperties(contract))
            {
                var propertyValue = property.ValueProvider.GetValue(value);
                if (property.Converter != null && property.Converter.CanWrite)
                    property.Converter.WriteJson(writer, propertyValue, serializer);
                else
                    serializer.Serialize(writer, propertyValue);
            }
            writer.WriteEndArray();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("invalid type {0}.", objectType.FullName));
            if (reader.MoveToContentAndAssert().TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartArray)
                throw new JsonSerializationException(string.Format("token {0} was not JsonToken.StartArray", reader.TokenType));
            // Not implemented: JsonObjectContract.CreatorParameters, serialization callbacks, 
            existingValue = existingValue ?? contract.DefaultCreator();
            using (var enumerator = SerializableProperties(contract).GetEnumerator())
            {
                while (true)
                {
                    switch (reader.ReadToContentAndAssert().TokenType)
                    {
                        case JsonToken.EndArray:
                            return existingValue;
                        default:
                            if (!enumerator.MoveNext())
                            {
                                reader.Skip();
                                break;
                            }
                            var property = enumerator.Current;
                            object propertyValue;
                            // TODO:
                            // https://www.newtonsoft.com/json/help/html/Properties_T_Newtonsoft_Json_Serialization_JsonProperty.htm
                            // JsonProperty.ItemConverter, ItemIsReference, ItemReferenceLoopHandling, ItemTypeNameHandling, DefaultValue, DefaultValueHandling, ReferenceLoopHandling, Required, TypeNameHandling, ...
                            if (property.Converter != null && property.Converter.CanRead)
                                propertyValue = property.Converter.ReadJson(reader, property.PropertyType, property.ValueProvider.GetValue(existingValue), serializer);
                            else
                                propertyValue = serializer.Deserialize(reader, property.PropertyType);
                            property.ValueProvider.SetValue(existingValue, propertyValue);
                            break;
                    }
                }
            }
        }
        static IEnumerable<JsonProperty> SerializableProperties(JsonObjectContract contract)
        {
            return contract.Properties.Where(p => !p.Ignored && p.Readable && p.Writable);
        }
    }
    public static partial class JsonExtensions
    {
        //https://stackoverflow.com/a/39462464/3744182
        public static JsonReader ReadToContentAndAssert(this JsonReader reader)
        {
            return reader.ReadAndAssert().MoveToContentAndAssert();
        }
        public static JsonReader MoveToContentAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (reader.TokenType == JsonToken.None)       // Skip past beginning of stream.
                reader.ReadAndAssert();
            while (reader.TokenType == JsonToken.Comment) // Skip past comments.
                reader.ReadAndAssert();
            return reader;
        }
        public static JsonReader ReadAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (!reader.Read())
                throw new JsonReaderException("Unexpected end of JSON stream.");
            return reader;
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
