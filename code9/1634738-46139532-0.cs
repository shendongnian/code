    class Program
    {
    
        static void Main(string[] args)
        {
            var value = JsonConvert.DeserializeObject<MasterData>(beginingDataRaw);
        }
    }
    
    [JsonConverter(typeof(MasterDataConverter))]
    public class MasterData
    {
        public int Id { get; set; }
        public long Seq { get; set; }
        public List<InnerObjects> Obj { get; set; }
    }
    
    [JsonConverter(typeof(InnerObjectsConverter))]
    public class InnerObjects
    {
        public string Id { get; set; }
        public OrderData Data { get; set; } 
    }
    
    public class OrderData
    {
        public string currencyPair { get; set; }
        public List<Dictionary<string, string>> orderBook { get; set; }
    }
    
    class InnerObjectsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(InnerObjects);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = new InnerObjects();
            value.Id = reader.ReadAsString();
            reader.Read();
            value.Data = serializer.Deserialize<OrderData>(reader);
            reader.Read();
            return value;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    class MasterDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                var value = new MasterData
                {
                    Id = (int)reader.ReadAsInt32(),
                    Seq = (long)(decimal)reader.ReadAsDecimal()
                };
                reader.Read();
                value.Obj = serializer.Deserialize<List<InnerObjects>>(reader);
                reader.Read();
                return value;
            }
            return null;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
