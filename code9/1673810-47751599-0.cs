    public static class Cloner
    {
        public static T Clone<T>(T source)
        {
            if (ReferenceEquals(source, null))
                return default(T);
            var settings = new JsonSerializerSettings { ContractResolver = new ContractResolver() };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, settings), settings);
        }
        class ContractResolver : DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Select(p => base.CreateProperty(p, memberSerialization))
                    .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                        .Select(f => base.CreateProperty(f, memberSerialization)))
                    .ToList();
                props.ForEach(p => { p.Writable = true; p.Readable = true; });
                return props;
            }
        }
    }
