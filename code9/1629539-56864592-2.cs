    public class ValueTuplesContractResolver : CamelCasePropertyNamesContractResolver
    {
        private readonly IList<string> _names;
        public ValueTuplesContractResolver(IList<string> names)
        {
            _names = names;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            for (var i = 0; i < properties.Count; i++)
            {
                properties[i].PropertyName = _names[i];
            }
            return properties;
        }
    }
