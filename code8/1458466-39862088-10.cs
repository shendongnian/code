    public class NullToEmptyStringResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties()
            .Select(p => {
                var jp = base.CreateProperty(p, memberSerialization);
                jp.ValueProvider = new EmptyToNullStringValueProvider(p);
                return jp;
            }).ToList();
        }
    }
    public class EmptyToNullStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public EmptyToNullStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }
        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target);
            if (_MemberInfo.PropertyType == typeof(string) && result != null && string.IsNullOrWhiteSpace(result.ToString()))
            {
                result = null;
            }
            return result;
        }
        public void SetValue(object target, object value)
        {
            if (_MemberInfo.PropertyType == typeof(string) && value != null && string.IsNullOrWhiteSpace(value.ToString()))
            {
                value = null;
            }
            _MemberInfo.SetValue(target, value);
        }
    }
