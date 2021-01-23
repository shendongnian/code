    public class EntityContractResolver : DefaultContractResolver
    {
        DateTimeConverter converter = null;
        DateTimeConverter Converter
        {
            get
            {
                if (converter == null)
                    converter = Interlocked.CompareExchange(ref converter, new DateTimeConverter(), null);
                return converter;
            }
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jProperty = base.CreateProperty(member, memberSerialization);
            if (jProperty.PropertyType == typeof(DateTime) || jProperty.PropertyType == typeof(DateTime?))
            {
                jProperty.Converter = jProperty.MemberConverter = Converter;
            }
            return jProperty;
        }
    }
