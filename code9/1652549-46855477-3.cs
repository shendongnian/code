    public static partial class JsonExtensions
    {
        public static bool AnyNull(this JToken rootNode)
        {
            if (rootNode == null)
                return true;
            // You might consider using some of the other checks from JsonExtensions.IsNullOrEmpty()
            // from https://stackoverflow.com/questions/24066400/checking-for-empty-null-jtoken-in-a-jobject
            return rootNode.DescendantsAndSelf()
                .OfType<JValue>()
                .Any(n => n.Type == JTokenType.Null);
        }
        public static IEnumerable<JToken> DescendantsAndSelf(this JToken rootNode)
        {
            if (rootNode == null)
                return Enumerable.Empty<JToken>();
            var container = rootNode as JContainer;
            if (container != null)
                return container.DescendantsAndSelf();
            else
                return new[] { rootNode };
        }
    }
