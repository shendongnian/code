 	public class ForceStringToArrayConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(IEnumerable<string[]>));
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var listObject = new List<string[]>();
			
			var jObject = JToken.Load(reader);
			foreach (JToken token in jObject.Children())
			{
				if (token.Type == JTokenType.Array)
				{
					var arrayObj = (JArray)token;
					listObject.Add(arrayObj.ToObject<string[]>());
				}
				else if (token.Type == JTokenType.String)
				{
					listObject.Add(new string[] { token.ToString() });
				}
			}
			return listObject;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
