    public static partial class JTokenExtensions
    {
        public static JObject [] FilterObjects<T>(this JObject root, string someProp, T someValue)
        {
            var comparer = new JTokenEqualityComparer();
            var someValueToken = JToken.FromObject(someValue);
            var objs = root.DescendantsAndSelf()
                .OfType<JObject>()
                .Where(t => comparer.Equals(t[someProp], someValueToken))
                .ToArray();
            return objs;
        }
    }
