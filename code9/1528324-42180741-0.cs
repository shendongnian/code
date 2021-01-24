    public static class JsonExtensions
    {
        public static TJToken RenamePropertiesToLowerInvariant<TJToken>(this TJToken root) where TJToken : JToken
        {
            return root.RenameProperties(s => s.ToLowerInvariant());
        }
        public static TJToken RenameProperties<TJToken>(this TJToken root, Func<string, string> map) where TJToken : JToken
        {
            if (map == null)
                throw new ArgumentNullException();
            if (root == null)
                return null;
            if (root is JProperty)
            {
                return RenameProperty(root as JProperty, map) as TJToken;
            }
            else
            {
                foreach (IList<JToken> obj in root.DescendantsAndSelf().OfType<JObject>())
                    for (int i = obj.Count - 1; i >= 0; i--)
                        ((JProperty)obj[i]).RenameProperty(map);
                return root;
            }
        }
        public static IEnumerable<JToken> DescendantsAndSelf(this JToken node)
        {
            if (node == null)
                return Enumerable.Empty<JToken>();
            var container = node as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new[] { node };
        }
        static JProperty RenameProperty(this JProperty property, Func<string, string> map)
        {
            // JProperty.Name is read only so it will need to be replaced in its parent.
            if (property == null)
                return null;
            var newName = map(property.Name);
            if (newName == property.Name)
                return property;
            var value = property.Value;
            // Setting Value to null prevents the child JToken hierarchy from getting cloned when added to the new JProperty
            property.Value = null; 
            var newProperty = new JProperty(newName, value);
            if (property.Parent != null)
                property.Replace(newProperty);
            return newProperty;
        }
    }
