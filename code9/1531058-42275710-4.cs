    public class ReturnNullConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            // Get the contract.
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
            // Allocate the object (it must have a parameterless constructor)
            existingValue = existingValue ?? contract.DefaultCreator();
            // Populate the values.
            serializer.Populate(reader, existingValue);
            // This checks for all properties being null.  Value types are never null, however the question
            // doesn't specify a requirement in such a case.  An alternative would be to check equality
            // with p.DefaultValue
            // http://www.newtonsoft.com/json/help/html/P_Newtonsoft_Json_Serialization_JsonProperty_DefaultValue.htm
            if (contract.Properties
                .Where(p => p.Readable)
                .All(p => object.ReferenceEquals(p.ValueProvider.GetValue(existingValue), null)))
                return null;
            return existingValue;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
