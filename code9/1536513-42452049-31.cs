    // Even though Properties is marked as Serializeable, it's 'data' property 
    // won't get serialized if we're serializing a reference to an ActorProperties.
    [Serializable] 
    public class Properties{
        public float data;
    }
    [Serializeable]
    public Class ActorProperties : Properties{
    
    	public int CurrentHealth;
    	public int MaxHealth;
    	public int Range;
    	public CustomClass SharedReference;
    	
    }
