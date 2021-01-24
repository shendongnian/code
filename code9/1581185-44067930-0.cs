	public class PackagesConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			throw new NotImplementedException();
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;
			List<string> res = new List<string>();
			var jsonArray = JArray.Load(reader);
			foreach (var i in jsonArray)
			{
				if (i.Count() > 1)
				{
					var name = i["name"];
					res.Add(name.ToString());
				}
				else
				{
					res.Add(i.ToString());
				}
			}
			return res;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
