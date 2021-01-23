    public static class JsonExtensions
    {
        public static IEnumerable<TJToken> RemoveFromLowestPossibleParent<TJToken>(this IEnumerable<TJToken> nodes) where TJToken : JToken
        {
            if (nodes == null)
                return null;
            foreach (var node in nodes.ToList())
                node.RemoveFromLowestPossibleParent();
            return nodes;
        }
        public static TJToken RemoveFromLowestPossibleParent<TJToken>(this TJToken node) where TJToken : JToken
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
