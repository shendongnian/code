    public static partial class JsonExtensions
    {
        public static bool AnyNullPropertyValues(this JToken rootNode)
        {
            if (rootNode == null)
                return true;
            foreach (var node in rootNode.DescendantsAndSelf().OfType<JProperty>())
            {
                if (node.Value == null || node.Value.Type == JTokenType.Null)
                    return true;
            }
            return false;
        }
    }
