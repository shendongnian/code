    public void Add(object value)
    {
    	//When T is decimal, then I get 
    	// System.InvalidCastException
    	var t = Convert.ChangeType(value, typeof(T));
    }
