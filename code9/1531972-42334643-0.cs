	public class IntConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value.GetType() == typeof(int))
				writer.WriteValue((int)value);
			else
				writer.WriteValue(value.ToString());
		}
	
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => 
			ParseInt(reader.Value.ToString());
		
		public override bool CanConvert(Type objectType) =>
			objectType == typeof(int) || objectType == typeof(string);
	
		private static int ParseInt(string value)
		{
			int parsedInt = 0;
			int.TryParse(value, out parsedInt);
			return parsedInt;
		}
	}
