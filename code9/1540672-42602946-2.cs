    public class IgnorePropertiesOfTypeContractResolver<T> : IgnorePropertiesOfTypeContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static IgnorePropertiesOfTypeContractResolver<T> instance;
        static IgnorePropertiesOfTypeContractResolver() { instance = new IgnorePropertiesOfTypeContractResolver<T>(); }
        public static IgnorePropertiesOfTypeContractResolver<T> Instance { get { return instance; } }
        public IgnorePropertiesOfTypeContractResolver() : base(new[] { typeof(T) }) { }
    }
    /// <summary>
    /// Contract resolver to ignore properties of any number of given types.
    /// </summary>
    public class IgnorePropertiesOfTypeContractResolver : DefaultContractResolver
    {
        readonly HashSet<Type> toIgnore;
        public IgnorePropertiesOfTypeContractResolver(IEnumerable<Type> toIgnore)
        {
            if (toIgnore == null)
                throw new ArgumentNullException();
            this.toIgnore = new HashSet<Type>(toIgnore);
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyType.BaseTypesAndSelf().Any(t => toIgnore.Contains(t)))
            {
                property.Ignored = true;
            }
            return property;
        }
    }
    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
