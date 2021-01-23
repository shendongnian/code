    public abstract class CustomJsonConverterBase : JsonConverter
    {
        protected abstract Type InferType(JToken token, Type objectType, object existingValue);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            var actualType = InferType(token, objectType, existingValue);
            if (existingValue == null || existingValue.GetType() != actualType)
            {
                var contract = serializer.ContractResolver.ResolveContract(actualType);
                existingValue = contract.DefaultCreator();
            }
            using (var subReader = token.CreateReader())
            {
                // Using "populate" avoids infinite recursion.
                serializer.Populate(subReader, existingValue);
            }
            return existingValue;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class CustomJsonConverter : CustomJsonConverterBase
    {
        public const string ClassPropertyName = @"_CurrentClassName";
        protected override Type InferType(JToken token, Type objectType, object existingValue)
        {
            if (token is JObject)
            {
                var typeName = (string)token[ClassPropertyName];
                if (typeName != null)
                {
                    var actualType = Type.GetType(objectType.Namespace + "." + typeName);
                    if (actualType != null)
                        return actualType;
                }
            }
            return objectType;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
