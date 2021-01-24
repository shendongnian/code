    void Main()
    {
    	Splitter.Print(Splitter.GetParts("945-20-4:397-3:320"));
    	Splitter.Print(Splitter.GetParts("945-20-41-90-4:397-3:320"));
    }
       
    unsafe static class Splitter
    {
    	public static ValueTuple<string, string> GetParts(string whole)
    	{
    		var builder = new StringBuilder();
    		
    		fixed (char* parts = whole)
    		{
    			char* lastDashPosition = null;
    			var terminus = parts + whole.Length;
    			for (var x = parts; x < terminus; ++x)
    			{
    				switch (*x)
    				{
    					case ':':
    					    var i = lastDashPosition - parts;
    						builder.Remove((int)(lastDashPosition  - parts), 
    							(int)(x - lastDashPosition));
    						return ValueTuple.Create(builder.ToString(), 
    							whole.Substring((int)(lastDashPosition + 1 - parts)));
    					case '-':
    						lastDashPosition = x;
    						break;
    				}
    				
    				builder.Append(*x);
    			}
    			
    			throw new InvalidOperationException("String not in expected format.");
    		}
    	}
    	
    	public static void Print(ValueTuple<string, string> v) 
    	{
    		Debug.Print("Token 1: " + v.Item1);
    		Debug.Print("Token 2: " + v.Item2);
    	}
    }
