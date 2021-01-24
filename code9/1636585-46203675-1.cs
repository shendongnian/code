    public class Data
    {
        [JsonConverter(typeof(SingleOrArrayConverter))]
        public int[][][] metaGrids;
    }
    class SingleOrArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<List<List<int>>>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                switch (Dimensions(token))
                {
                    case 3:
                        return token.ToObject<int[][][]>();
                    case 2:
                        return new int[][][] { token.ToObject<int[][]>() };
                }
            }
            throw new InvalidOperationException("Data is not in a standard supported format.");
        }
        private static int Dimensions(JToken token)
        {
            if (token.Type != JTokenType.Array)
                return 0;
            return 1 + Dimensions(token.First);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
