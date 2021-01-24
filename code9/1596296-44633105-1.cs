    public class CustomContractResolver : DefaultContractResolver
    {
        public bool UseCleanName { get; }
        private Dictionary<string, string> PropertyMappings { get; set; }
        
        public CustomContractResolver(bool useCleanName)
        {
            UseCleanName = useCleanName;
            this.PropertyMappings = new Dictionary<string, string>
            {
                {"ErrorMessage", "error_message"}
            };
        }
        protected override string ResolvePropertyName(string propertyName)
        {
            var mapping = PropertyMappings.Where(keyValue => keyValue.Key == propertyName || keyValue.Value == propertyName).ToArray();
            return !mapping.Any() ? propertyName : UseCleanName ? mapping.FirstOrDefault().Value : mapping.FirstOrDefault().Key;
        }
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
