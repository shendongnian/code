	public class NumberConverter : JsonConverter
	{
		public override bool CanWrite => false;
		public override bool CanConvert(Type objectType)
		{
			return typeof(ulong) == objectType;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var value = reader.Value.ToString();
			ulong result;
			if (string.IsNullOrEmpty(value) || !ulong.TryParse(value, out result))
			{
				return default(ulong);
			}
			return result;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
