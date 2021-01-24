    internal sealed class MyContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty( MemberInfo member, MemberSerialization memberSerialization )
		{
			var property = base.CreateProperty( member, memberSerialization );
            if( member.DeclaringType == typeof( foo ) && property.PropertyType == typeof( MyEnum ) )
            {
                property.Converter = null;
            }
			
			return property;
		}
    }
