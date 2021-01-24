    public class JsonProductConverted : JsonTypeInferringConverterBase
    {
		protected override Type InferType(Type objectType, JObject json)
		{
			//var type = GetTypeFromId((int) json["typeId"]); // Construct type from field in 
			return typeof(ProductImpl);
		}
		
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
    public abstract class JsonTypeInferringConverterBase : JsonConverter
	{
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
		protected abstract Type InferType(Type objectType, JObject json);
		
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var json = JObject.Load(reader);
			
            var actualType = InferType(objectType, json);
			// Construct object (or reuse existingValue if compatible)
			if (existingValue == null || !actualType.IsAssignableFrom(existingValue.GetType()))
			{
	            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(actualType);
            	existingValue = contract.DefaultCreator();
			}
			
			// Populate object.
            using (var subReader = json.CreateReader())
            {
                serializer.Populate(subReader, existingValue);
            }
			return existingValue;
        }
	}
