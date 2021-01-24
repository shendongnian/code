    public static class CollectionHandler {
        private static BindingList<string> _origFileList;
        public static IList<string> origFileList
    	{
    		get=> _origFileList;
    		set
    		{
    			if(value == null) throw new ArgumentNullException();
    			if(_origFileList != null)
    				_origFileList.ListChanged -= OnListChanged;
    			_origFileList = new BindingList<string>(value); 
    			_origFileList.ListChanged += OnListChanged;
    		}
    	}
    	
    	static void OnListChanged(object sender, ListChangedEventArgs e)
    	{
    		if(_origFileList.Count== 0)
    			myTestCallback();
    	}
    
    	static CollectionHandler()
    	{
    		origFileList = new List<string>();
    	}
    	
        private static void myTestCallback() {
            Console.WriteLine("origFileList - Is now empty");
        }
    }
