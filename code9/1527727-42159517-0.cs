    void Main()
    {
    	var arr = new object[2];
    	arr[0] = 1;
    	arr[1] = (Action)DoIt;
    
    	foreach (var a in arr)
    	{
    		if (a is Action)
    		{
    			((Action)a)();
    		}
    		else
    		{
    			Console.WriteLine(a.ToString());
    		}
    	}
    }
    
    
    public void DoIt()
    {
    	Console.WriteLine("did");		
    }
