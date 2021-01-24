    public class ValueTuplesContractResolver : CamelCasePropertyNamesContractResolver
    {
        private IList<string> _names;
        public ValueTuplesContractResolver(IList<string> names)
        {
            _names = names;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            if (type.Name.Contains(nameof(ValueTuple)))
            {
                for (var i = 0; i < properties.Count; i++)
                {
                    properties[i].PropertyName = _names[i];
                }
                _names = _names.Skip(properties.Count).ToList();
            }
            return properties;
        }
    }
