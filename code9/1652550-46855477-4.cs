    public static partial class JsonExtensions
    {
        public static bool AnyNullPropertyValues(this JToken rootNode)
        {
            if (rootNode == null)
                return true;
            return rootNode.DescendantsAndSelf()
                .OfType<JProperty>()
                .Any(p => p.Value == null || p.Value.Type == JTokenType.Null);
        }
    }
