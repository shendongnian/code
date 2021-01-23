    class MyContractResolver<T> : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var list = base.CreateProperties(type, memberSerialization);
            var baseProps = typeof(T).GetProperties();
            foreach (var prop in list)
            {
                prop.Ignored = baseProps?.All(p => p.Name != prop.PropertyName) ?? false;
            }
            return list;
        }
    }
