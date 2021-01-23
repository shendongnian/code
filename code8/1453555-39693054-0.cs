    public class ISerializableRealObjectContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        static ISerializableRealObjectContractResolver instance;
        static ISerializableRealObjectContractResolver() { instance = new ISerializableRealObjectContractResolver(); }
        public static ISerializableRealObjectContractResolver Instance { get { return instance; } }
        public ISerializableRealObjectContractResolver()
            : base()
        {
            this.IgnoreSerializableInterface = false;
        }
        protected override JsonISerializableContract CreateISerializableContract(Type objectType)
        {
            var contract = base.CreateISerializableContract(objectType);
            var constructor = contract.ISerializableCreator;
            contract.ISerializableCreator = args => 
            {
                var obj = constructor(args);
                if (obj is IObjectReference)
                {
                    var context = (StreamingContext)args[1];
                    obj = ((IObjectReference)obj).GetRealObject(context);
                }
                return obj;
            };
            return contract;
        }
    }
