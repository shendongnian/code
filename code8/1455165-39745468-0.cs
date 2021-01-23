    public class SomePerson : MonoBehaviour 
    {
    	//This field gets serialized because it is public.
    	public string name = "John";
    
    	//This field does not get serialized because it is private.
    	private int age = 40;
    
    	//This field gets serialized even though it is private
    	//because it has the SerializeField attribute applied.
    	[SerializeField]
    	private bool hasHealthPotion = true;
    
        // This will be displayed in inspector because the class has Serialized attribute.
        public SomeCustomClass somCustomClassInstance;
    
    }
    
    [System.Serializable]
    public class SomeCustomClass
    {
        public string someProperty;
    }
