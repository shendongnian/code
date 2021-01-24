    public class JsonProductConverted : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            JObject json = JObject.Load(reader);
            //var type = GetTypeFromId((int) json["typeId"]); // Construct type from field in 
            var type = typeof(ProductImpl);
            // var res = JsonConvert.DeserializeObject(json.ToString(), type, DEFAULT_JSONCONVERTER_HERE);
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(type);
            var res = existingValue as Product ?? (Product)contract.DefaultCreator();
            using (var subReader = json.CreateReader())
            {
                serializer.Populate(subReader, res);
            }
			return res;
        }
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
