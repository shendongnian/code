    // Where Lib is the type that contains the Send method.
    public static class MyExtensions
    {
    	public static void Send(this Lib lib, string type, object obj)
        {
    		lib.Send(type, new[]{ obj });
        }
    	
    	public static void Send(this Lib lib, string type, List<object> objs)
        {
    		lib.Send(type, objs.ToArray());
        }
       
        // Other overloads
    }
