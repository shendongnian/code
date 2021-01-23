    internal class MyObjectJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
		
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dataList = value as List<RootObject>;
            writer.WriteStartObject();
            foreach (var data in dataList)
            {   
                writer.WritePropertyName(data.description);
                writer.WriteValue(data.value);
            }
            writer.WriteEndObject();
        }
	}
