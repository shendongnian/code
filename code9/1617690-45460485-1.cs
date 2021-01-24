    public MyClass
    {	
        public string MyProp { get; set; }
        public string ExcludeThisProp { get; set; }
        public int MyNumber { get; set; }
        public int ExcludeIfMeetsCondition { get; set; }
    	
    	//Define should serialize options    	
    	public bool ShouldSerializeExcludeMyProp() { return (false); } //Will always exclude
    	public bool ShouldSerializeExcludeIfMeetsCondition() 
    	{ 
    		if (ExcludeIfMeetsCondition > 10)
    			return true;
    		else if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
    			return true;
    		else
    			return false; 
    	} 
    }
