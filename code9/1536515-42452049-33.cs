    // Even though Properties is marked as Serializeable, it's 'data' property 
    // won't get serialized if we're serializing a reference to an ActorProperties.
    // No native support for polymorphic serialization of custom classes.
    [Serializable] 
    public class Properties{
        public float data;
    }
    [Serializeable]
    public class ActorProperties : Properties{
        // Here we have a recursion problem because Unity cannot serialize 
        // null values for custom classes. Unity will try to serialize this ActorProperties field, which in turn starts the serialization over again,
        // with an iteration depth of 7. Killer if it were a List<ActorProperties> .
        public ActorProperties EnemyProperties; 
    	public int CurrentHealth;
    	public int MaxHealth;
    	public int Range;
        // Since Unity treats custom classes like structs, the following field wont be serialized 
        // as a pointer to an existing object, but as a unique instance of it's class.
    	public CustomClass SharedReference;
    	
    }
