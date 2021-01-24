    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
    public class AddJsonTypenameAttribute : System.Attribute
    {
    }
    public class AddJsonTypenameContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static AddJsonTypenameContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static AddJsonTypenameContractResolver() { instance = new AddJsonTypenameContractResolver(); }
        public static AddJsonTypenameContractResolver Instance { get { return instance; } }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            return base.CreateProperty(member, memberSerialization)
                .ApplyAddTypenameAttribute();
        }
        protected override JsonArrayContract CreateArrayContract(Type objectType)
        {
            return base.CreateArrayContract(objectType)
                .ApplyAddTypenameAttribute();
        }
    }
    public static class ContractResolverExtensions
    {
        public static JsonProperty ApplyAddTypenameAttribute(this JsonProperty jsonProperty)
        {
            if (jsonProperty.TypeNameHandling == null)
            {
                if (jsonProperty.PropertyType.GetCustomAttribute<AddJsonTypenameAttribute>(false) != null)
                {
                    jsonProperty.TypeNameHandling = TypeNameHandling.All;
                }
            }
            return jsonProperty;
        }
        public static JsonArrayContract ApplyAddTypenameAttribute(this JsonArrayContract contract)
        {
            if (contract.ItemTypeNameHandling == null)
            {
                if (contract.CollectionItemType.GetCustomAttribute<AddJsonTypenameAttribute>(false) != null)
                {
                    contract.ItemTypeNameHandling = TypeNameHandling.All;
                }
            }
            return contract;
        }
    }
