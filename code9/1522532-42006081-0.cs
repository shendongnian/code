    class MyValuesConverter : CustomPropertyConverterBase<MyValues>
    {
        protected override void ProcessCustomProperties(JObject obj, MyValues value, JsonSerializer serializer)
        {
            // Remove the value property for manual deserialization, and deserialize
            var jValue = obj.GetValue("value", StringComparison.OrdinalIgnoreCase).RemoveFromLowestPossibleParent();
            if (jValue != null)
            {
                (value.Values = value.Values ?? new List<Stuff>()).Clear();
                value.Values.Add(jValue.ToObject<Stuff>(serializer));
            }
        }
    }
    public abstract class CustomPropertyConverterBase<T> : JsonConverter where T : class
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jObj = JObject.Load(reader);
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(objectType);
            var value = existingValue as T ?? (T)contract.DefaultCreator();
            ProcessCustomProperties(jObj, value, serializer);
            // Populate the remaining properties.
            using (var subReader = jObj.CreateReader())
            {
                serializer.Populate(subReader, value);
            }
            return value;
        }
        protected abstract void ProcessCustomProperties(JObject obj, T value, JsonSerializer serializer);
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
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
