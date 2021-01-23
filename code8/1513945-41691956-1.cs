	public class KeyValuePairJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			List<KeyValuePair<string, string>> list = value as List<KeyValuePair<string, string>>;
			writer.WriteStartArray();
			foreach(var item in list)
			{
				writer.WriteStartObject();
				writer.WritePropertyName(item.Key.ToString());
				writer.WriteValue(item.Value.ToString());
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
		}
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(List<KeyValuePair<string, string>>);
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var jsonObject = JObject.Load(reader);
			var target = Create(objectType, jsonObject);
			serializer.Populate(jsonObject.CreateReader(), target);
			return target;
		}
		private object Create(Type objectType, JObject jsonObject)
		{
			if(FieldExists("Key", jsonObject))
			{
				return jsonObject["Key"].ToString();
			}
			if(FieldExists("Value", jsonObject))
			{
				return jsonObject["Value"].ToString();
			}
			return null;
		}
		private bool FieldExists(string fieldName, JObject jsonObject)
		{
			return jsonObject[fieldName] != null;
		}
	}
	
