    public abstract class FuzzyMatchingJsonConverterBase : JsonConverter
    {
        protected abstract JsonProperty FindProperty(JsonObjectContract contract, string propertyName);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;
            if (contract == null)
                throw new JsonSerializationException(string.Format("Contract for type {0} is not a JsonObjectContract", objectType));
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
            existingValue = existingValue ?? contract.DefaultCreator();
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Comment:
                        break;
                    case JsonToken.PropertyName:
                        {
                            var propertyName = (string)reader.Value;
                            reader.ReadAndAssert();
                            var jsonProperty = FindProperty(contract, propertyName);
                            if (jsonProperty == null)
                                continue;
                            object itemValue;
                            if (jsonProperty.Converter != null && jsonProperty.Converter.CanRead)
                            {
                                itemValue = jsonProperty.Converter.ReadJson(reader, jsonProperty.PropertyType, jsonProperty.ValueProvider.GetValue(existingValue), serializer);
                            }
                            else
                            {
                                itemValue = serializer.Deserialize(reader, jsonProperty.PropertyType);
                            }
                            jsonProperty.ValueProvider.SetValue(existingValue, itemValue);
                        }
                        break;
                    case JsonToken.EndObject:
                        return existingValue;
                    default:
                        throw new JsonSerializationException(string.Format("Unexpected token {0}", reader.TokenType));
                }
            }
            throw new JsonReaderException("Unexpected EOF!");
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class FuzzySnakeCaseMatchingJsonConverterBase : FuzzyMatchingJsonConverterBase
    {
        protected override JsonProperty FindProperty(JsonObjectContract contract, string propertyName)
        {
            // Remove snake-case underscore.
            propertyName = propertyName.Replace("_", "");
            // And do a case-insensitive match.
            return contract.Properties.GetClosestMatchProperty(propertyName);
        }
    }
    // This type should be applied via attributes.
    public class FuzzySnakeCaseMatchingJsonConverter : FuzzySnakeCaseMatchingJsonConverterBase
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
    // This type can be used in JsonSerializerSettings.Converters
    public class GlobalFuzzySnakeCaseMatchingJsonConverter : FuzzySnakeCaseMatchingJsonConverterBase
    {
        readonly IContractResolver contractResolver;
        public GlobalFuzzySnakeCaseMatchingJsonConverter(IContractResolver contractResolver)
        {
            this.contractResolver = contractResolver;
        }
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsPrimitive || objectType == typeof(string))
                return false;
            var contract = contractResolver.ResolveContract(objectType);
            return contract is JsonObjectContract;
        }
    }
    public static class JsonReaderExtensions
    {
        public static void ReadAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (!reader.Read())
                throw new JsonReaderException("Unexpected EOF!");
        }
    }
