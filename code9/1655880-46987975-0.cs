	public class DetailsConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return typeof(Details) == objectType;
		}
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			var value = obj["response"]?["details"]?.FirstOrDefault();
			if (value == null) { return null; }
			return value.ToObject<Details>();
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
