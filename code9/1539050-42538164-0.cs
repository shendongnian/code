    [JsonConverter(typeof(PropertyValueConverter))]
    public sealed class PropertyValue
    {
        public PropertyValue(object CurrentValue)
        {
            SetCurrentValue(CurrentValue);
        }
        public PropertyValue()
        {
        }
        public string PropertyName { get; set; }
        public string CategoryName { get; set; }
        public string DisplayName { get; set; }
        public int PropertyId { get; set; }
        public string TypeName { get; set; }
        public string ToolTip { get; set; }
        public string Description { get; set; }
        public object CurrentValue { get; set; }
        public void SetCurrentValue(object value)
        {
            CurrentValue = value;
            if (value == null)
                TypeName = null;
            else
                TypeName = value.GetType().AssemblyQualifiedName;
        }
    }
    public class PropertyValueConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(PropertyValue).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var propertyValue = (existingValue as PropertyValue ?? new PropertyValue());
            var obj = JObject.Load(reader);
            // Remove the CurrentValue property for manual deserialization, and deserialize
            var jValue = obj.GetValue("CurrentValue", StringComparison.OrdinalIgnoreCase).RemoveFromLowestPossibleParent();
            // Load the remainder of the properties
            serializer.Populate(obj.CreateReader(), propertyValue);
            // Convert the type name to a type.
            // Use the serialization binder to sanitize the input type!  See
            // https://stackoverflow.com/questions/39565954/typenamehandling-caution-in-newtonsoft-json
            if (!string.IsNullOrEmpty(propertyValue.TypeName) && jValue != null)
            {
                string typeName, assemblyName;
                ReflectionUtils.SplitFullyQualifiedTypeName(propertyValue.TypeName, out typeName, out assemblyName);
                var type = serializer.Binder.BindToType(assemblyName, typeName);
                if (type != null)
                    propertyValue.SetCurrentValue(jValue.ToObject(type, serializer));
            }
            return propertyValue;
        }
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
    public static class ReflectionUtils
    {
        // Utilities taken from https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Utilities/ReflectionUtils.cs
        // I couldn't find a way to access these directly.
        public static void SplitFullyQualifiedTypeName(string fullyQualifiedTypeName, out string typeName, out string assemblyName)
        {
            int? assemblyDelimiterIndex = GetAssemblyDelimiterIndex(fullyQualifiedTypeName);
            if (assemblyDelimiterIndex != null)
            {
                typeName = fullyQualifiedTypeName.Substring(0, assemblyDelimiterIndex.GetValueOrDefault()).Trim();
                assemblyName = fullyQualifiedTypeName.Substring(assemblyDelimiterIndex.GetValueOrDefault() + 1, fullyQualifiedTypeName.Length - assemblyDelimiterIndex.GetValueOrDefault() - 1).Trim();
            }
            else
            {
                typeName = fullyQualifiedTypeName;
                assemblyName = null;
            }
        }
        private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName)
        {
            int scope = 0;
            for (int i = 0; i < fullyQualifiedTypeName.Length; i++)
            {
                char current = fullyQualifiedTypeName[i];
                switch (current)
                {
                    case '[':
                        scope++;
                        break;
                    case ']':
                        scope--;
                        break;
                    case ',':
                        if (scope == 0)
                        {
                            return i;
                        }
                        break;
                }
            }
            return null;
        }
    }
