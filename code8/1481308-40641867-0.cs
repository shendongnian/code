	public class MainStuff : IMainStuff
	{ 
		[JsonProperty(ItemConverterType = typeof(TypeConverter<SubStuff>))]
		public Dictionary<string, ISubStuff> SubStuff
		{ 
			get; 
			set; 
		} 
	}
	public class TypeConverter<T> : JsonConverter
	{
		public override bool CanConvert(Type objectType) 
		{
			var msg = string.Format("This converter should be applied directly with [JsonProperty(ItemConverterType = typeof(TypeConverter<{0}>))] or [JsonProperty(typeof(TypeConverter<{0}>))]", 
									typeof(T));
            throw new NotImplementedException(msg);
		}
		
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return serializer.Deserialize<T>(reader);
		}
	}
