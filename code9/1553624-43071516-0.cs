    public class EntryComparer : IEqualityComparer<JObject>
    {
        private static readonly JTokenEqualityComparer _comparer = new JTokenEqualityComparer();
        private static readonly string _excludedPrefix = "tbp_";
        public static JObject CloneForComparison(JObject obj)
        {
            var clone = obj.DeepClone() as JObject;
            var propertiesToRemove = clone
                .Properties()
                .Where(p => p.Name.StartsWith(_excludedPrefix))
                .ToArray();
            foreach (var property in propertiesToRemove)
            {
                property.Remove();
            }
            return clone;
        }
        public bool Equals(JObject obj1, JObject obj2)
        {
            return _comparer.Equals(CloneForComparison(obj1), CloneForComparison(obj2));
        }
        public int GetHashCode(JObject obj)
        {
            return _comparer.GetHashCode(CloneForComparison(obj));
        }
    }
