    public static class TagHelperAttributeListExtensions
    {
        public static void Merge(this TagHelperAttributeList attributes, string name, object value)
        {
            var attr = attributes.FirstOrDefault(a => a.Name == name);
            if (attr != null)
            {
                attributes.Remove(attr);
            }
            attributes.Add(name, $"{value} {attr?.Value}");
        }
    }
