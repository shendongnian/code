    public static partial class JTokenExtensions
    {
        public static bool IsNull(this JToken token)
        {
            return token == null || token.Type == JTokenType.Null;
        }
        public static JObject[] FilterObjectsSimple<T>(this JObject root, string someProp, T someValue)
        {
            var comparer = EqualityComparer<T>.Default;
            var objs = root.DescendantsAndSelf()
                .OfType<JObject>()
                .Where(t => { var v = t[someProp]; return v != null && (someValue == null ? v.IsNull() : comparer.Equals(v.ToObject<T>(), someValue)); })
                .ToArray();
            return objs;
        }
    }
