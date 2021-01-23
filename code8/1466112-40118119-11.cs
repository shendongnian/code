    public static partial class JsonExtensions
    {
        public static TJToken RemoveFromLowestPossibleParent<TJToken>(this TJToken node) where TJToken : JToken
        {
            if (node == null)
                return null;
            JToken toRemove;
            var property = node.Parent as JProperty;
            if (property != null)
            {
                // Also detach the node from its immediate containing property -- Remove() does not do this even though it seems like it should
                toRemove = property;
                property.Value = null;
            }
            else
            {
                toRemove = node;
            }
            if (toRemove.Parent != null)
                toRemove.Remove();
            return node;
        }
        public static IEnumerable<TJToken> RemoveFromLowestPossibleParents<TJToken>(this IEnumerable<TJToken> nodes) where TJToken : JToken
        {
            var list = nodes.ToList();
            foreach (var node in list)
                node.RemoveFromLowestPossibleParent();
            return list;
        }
    }
