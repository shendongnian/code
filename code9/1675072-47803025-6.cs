    public static class JsonExtensions
    {
        const string valuesName = "$values";
        const string typeName = "$type";
        public static JToken RemoveTypeMetadata(this JToken root)
        {
            if (root == null)
                throw new ArgumentNullException();
            var types = root.SelectTokens(".." + typeName).Select(v => (JProperty)v.Parent).ToList();
            foreach (var typeProperty in types)
            {
                var parent = (JObject)typeProperty.Parent;
                typeProperty.Remove();
                var valueProperty = parent.Property(valuesName);
                if (valueProperty != null && parent.Count == 1)
                {
                    // Bubble the $values collection up removing the synthetic container object.
                    var value = valueProperty.Value;
                    if (parent == root)
                    {
                        root = value;
                    }
                    // Remove the $values property, detach the value, then replace it in the parent's parent.
                    valueProperty.Remove();
                    valueProperty.Value = null;
                    if (parent.Parent != null)
                    {
                        parent.Replace(value);
                    }
                }
            }
            return root;
        }
    }
