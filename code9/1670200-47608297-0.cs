    public static FileManager
    {
    
    	// You can change this to a Dictionary or whatefver you need
    	public static readonly List<string> Data { get; }
    
    
    	// Static constructor, will be called once
        // Here you will populate your data
    	static FileManager()
    	{
    		Data = new List<string>();
    		// Read from file and add data to Data, assuming the data is lines
    	}
    
    }
