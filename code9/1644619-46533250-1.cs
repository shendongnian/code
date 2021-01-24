    public class SkipEmptyCollectionsContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization)
                .AddShouldSerializeEmptyCollections(this);
            return property;
        }
    }
    public static class JsonPropertyExtensions
    {
        public static JsonProperty AddShouldSerializeEmptyCollections(this JsonProperty property, IContractResolver resolver)
        {
            if (property == null)
                throw new ArgumentNullException();
            if ((typeof(IEnumerable).IsAssignableFrom(property.PropertyType) || property.PropertyType.IsAssignableFrom(typeof(IEnumerable)))
                && property.PropertyType != typeof(string)
                && property.Readable)
            {
                Predicate<object> shouldSerialize = (parent) =>
                {
                    var value = property.ValueProvider.GetValue(parent);
                    if (value == null || value is string)
                        return true; // null properties are filtered by the NullValueHandling setting.
                    var contract = resolver.ResolveContract(value.GetType());
                    if (contract is JsonArrayContract)
                    {
                        return (value as IEnumerable).Any();
                    }
                    return true;
                };
                var oldShouldSerialize = property.ShouldSerialize;
                if (oldShouldSerialize == null)
                    property.ShouldSerialize = shouldSerialize;
                else
                    property.ShouldSerialize = (o) => shouldSerialize(o) && oldShouldSerialize(o);
            }
            return property;
        }
    }
    public static class EnumerableExtensions
    {
        public static bool Any(this IEnumerable enumerable)
        {
            if (enumerable == null)
                return false;
            if (enumerable is ICollection)
            {
                return ((ICollection)enumerable).Count > 0;
            }
            var enumerator = enumerable.GetEnumerator();
            using (enumerator as IDisposable)
            {
                return enumerator.MoveNext();
            }
        }
    }
