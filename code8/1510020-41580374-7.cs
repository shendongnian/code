	public class MyTestClassConverter : JsonConverter
	{
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
			var root = existingValue as MyTestClass ?? (MyTestClass)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
	        var jsonObject = JObject.Load(reader);
			var jsonItems = jsonObject["Items"].RemoveFromLowestPossibleParent();
			if (jsonItems != null && jsonItems.Type != JTokenType.Null)
			{
				root.Items.AddRange(jsonItems.ToObject<List<string []>>());
			}
			// Populate the remaining standard properties
			using (var subReader = jsonObject.CreateReader())
			{
				serializer.Populate(subReader, root);
			}
			return root;
        }
        public override bool CanConvert(Type objectType)
        {
			return typeof(MyTestClass).IsAssignableFrom(objectType);
        }
	}
	public static class JsonExtensions
	{
		public static JToken RemoveFromLowestPossibleParent(this JToken node)
		{
			if (node == null)
				return null;
			var contained = node.AncestorsAndSelf().Where(t => t.Parent is JContainer && t.Parent.Type != JTokenType.Property).FirstOrDefault();
			if (contained != null)
				contained.Remove();
			// Also detach the node from its immediate containing property -- Remove() does not do this even though it seems like it should
			if (node.Parent is JProperty)
				((JProperty)node.Parent).Value = null;
			return node;
		}
	}
