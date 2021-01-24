    private void Main()
    {
    	object[] a = {1,2,3};
    	object[] b = {4,5,a};
    	Recursive(b);
    }
    // mdia = multiple-dimension-integer-array
    public void Recursive(Array mdia)
    {
    	foreach (var element in mdia)
	    {
		    if (element is int)
			    result.Add(element);
    		else
    			Recursive((Array)element);
    	}
    }
