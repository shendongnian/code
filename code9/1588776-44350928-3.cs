	public class FooToBarConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return true;
		}
	
		public override void WriteJson(
            JsonWriter writer, 
            object value, 
            JsonSerializer serializer)
		{
			Foo foo = (Foo)value;
			JObject jo = new JObject();
			jo.Add("BarId", new JValue(foo.Id));
			jo.Add("BarName", new JValue(foo.Name));
			jo.WriteTo(writer);
		}
	
		public override object ReadJson(
            JsonReader reader, 
            Type objectType, 
            object existingValue, 
            JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
