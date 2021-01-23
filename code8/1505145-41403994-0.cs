    public class ExternalType
    	{
    		public class InternalType
    		{
    			internal InternalType(string someString) 
    			{
    				SomeStringProp = someString;
    			}
    	
    			public string SomeStringProp { get; private set; }
    		}
    	
    		public readonly List<InternalType> InternalTypes = new List<InternalType>() 
    		{
    			new InternalType("test") 
    		};
    	}
