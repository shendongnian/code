    string json = @"{""name"":""somename"", ""type"":""sometype"" }";
    var settings = new JsonSerializerSettings() { 
                             ContractResolver = new AllPropertiesContractResolver() };
    var res = JsonConvert.DeserializeObject<MyClass>(json,settings);
    public class MyClass
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
    }
----
    public class AllPropertiesContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                        .Select(x => new Newtonsoft.Json.Serialization.JsonProperty()
                        {
                            PropertyName = x.Name,
                            PropertyType = x.PropertyType,
                            Readable = true,
                            ValueProvider = new AllPropertiesValueProvider(x),
                            Writable = true
                        })
                        .ToList();
                
                
            return props;
        }
    }
    public class AllPropertiesValueProvider : Newtonsoft.Json.Serialization.IValueProvider
    {
        PropertyInfo _propertyInfo;
        public AllPropertiesValueProvider(PropertyInfo p)
        {
            _propertyInfo = p;
        }
        public object GetValue(object target)
        {
            return _propertyInfo.GetValue(target);  //Serialization
        }
        public void SetValue(object target, object value)
        {
            _propertyInfo.SetValue(target, value, null); //Deserialization
        }
    }
