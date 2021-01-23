    public class CustomContractResolver : DefaultContractResolver
    {
    	public static readonly CustomContractResolver Instance = new CustomContractResolver();
    	
    	protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    	{
    		JsonProperty property = base.CreateProperty(member, memberSerialization);
    		
            // Ignore get-only properties that do not have a [JsonProperty] attribute
    		if (!property.Writable && member.GetCustomAttribute<JsonPropertyAttribute>() == null)
    			property.Ignored = true;
    		
    		return property;
    	}
    }
