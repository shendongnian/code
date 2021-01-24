    interface IMyClass {
        IList<int> MyList { get; set; }
        void AddToList(int newVal);
    }
    
    public class MyClass: IMyClass {
    	private readonly List<int> myPrivateList;
    	
        public IList<int> MyList { get; set; }
    	
    	public MyClass()
    	{
    		// Create private list used internally
    		myPrivateList = new List<int>();
    		
    		// Create read-only wrapper around myPrivateList used for the public MyList property
    		MyList = new ReadOnlyCollection<int>(myPrivateList);
    	}
    	
        public void AddToList(int newVal)
        {
            // Use myPrivateList instead of MyList
            myPrivateList.Add(newVal);
        }
    }
