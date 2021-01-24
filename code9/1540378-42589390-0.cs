    public class JsonInvoker
    {
        private readonly MethodInfo _methodInfo;
        private readonly Type _paramType;
        private readonly JsonSerializerSettings _settings;
        public JsonInvoker(Type instanceType, string methodName)
        {
            _methodInfo = instanceType.GetMethod(methodName);
            _paramType = _methodInfo.GetParameters()[0].ParameterType;
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new RequireObjectPropertiesContractResolver(),
                MissingMemberHandling = MissingMemberHandling.Error
            };
        }
        public object Invoke(object instance, string json)
        {
            var input = JsonConvert.DeserializeObject(json, _paramType, _settings);
            var output = _methodInfo.Invoke(instance, new[] { input });
            return output;
        }
        private class RequireObjectPropertiesContractResolver : DefaultContractResolver
        {
            protected override JsonObjectContract CreateObjectContract(Type objectType)
            {
                var contract = base.CreateObjectContract(objectType);
                contract.ItemRequired = Required.AllowNull;
                return contract;
            }
        }
    }
