	public class Color
	{
		public string Title { get; set; }
		public string ColorName { get; set; }
	}
	public class ColorsConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Color[]);
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var colors = (Color[]) value;
			var temp = colors.ToDictionary(x => x.Title, x => x.ColorName);
			serializer.Serialize(writer, temp);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
