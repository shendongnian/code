    public class GenericTypeJsonSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Parse data object
            var dataObject = JToken.FromObject(value);
            
            // Extract generic type class serialization name
            var className = ExtractClassName(value);
            // Create wrapper object that includes generic class name
            JObject wrapperObject = new JObject();
            wrapperObject.Add(className, dataObject);
            // write object
            wrapperObject.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public string ExtractClassName(object value)
        {
            // extract data contract attribute
            var dataContractAttribute = value.GetType()
                .GetCustomAttribute(typeof(DataContractAttribute)) as DataContractAttribute;
            // return name declared in attribute
            if (dataContractAttribute?.Name != null)
                return dataContractAttribute.Name;
            // return default class name
            return value.GetType().Name;
        }
    }
