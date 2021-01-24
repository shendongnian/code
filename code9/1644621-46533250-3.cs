    public enum EmptyArrayHandling
    {
        Include = 0,
        Ignore = 1,
    }
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class JsonPropertyExtensionsAttribute : System.Attribute
    {
        public EmptyArrayHandling EmptyArrayHandling { get; set; }
    }
    public class ConditionallySkipEmptyCollectionsContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var attr = property.AttributeProvider.GetAttributes(typeof(JsonPropertyExtensionsAttribute), false).Cast<JsonPropertyExtensionsAttribute>().FirstOrDefault();
            if (attr != null && attr.EmptyArrayHandling == EmptyArrayHandling.Ignore)
                property = property.AddShouldSerializeEmptyCollections(this);
            return property;
        }
    }
