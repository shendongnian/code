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
        // This will not be shown in inspector even if it is public.
        [HideInInspector]
        public bool hiddenBool;    
        // Same with this one.
        [System.NonSerialized]
        public int nonSerializedVariable = 5;
    }
    
    [System.Serializable]
    public class SomeCustomClass
    {
        public string someProperty;
    }
