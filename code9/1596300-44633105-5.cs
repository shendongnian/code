    public class CustomContractResolver : DefaultContractResolver
    {
        public bool UseJsonPropertyName { get; }
        public CustomContractResolver(bool useJsonPropertyName)
        {
            UseJsonPropertyName = useJsonPropertyName;
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (!UseJsonPropertyName)
                property.PropertyName = property.UnderlyingName;
            return property;
        }
    }
    public class ErrorDetails
    {
        public int Id { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
    var json = "{'Id': 1,'error_message': 'An error has occurred!'}";
    var serializerSettings = new JsonSerializerSettings()
    {
        ContractResolver = new CustomContractResolver(false)
    };
    var dezerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new CustomContractResolver(true)
    };
    var obj = JsonConvert.DeserializeObject<ErrorDetails>(json, dezerializerSettings);
    var jsonNew = JsonConvert.SerializeObject(obj, serializerSettings);
