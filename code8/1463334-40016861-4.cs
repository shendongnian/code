    static void Main(string[] args)    {
	    BAL b = new BAL();
	    var ll = b.GetFieldList("xxxxyyyy");
    }
    public class BAL
    {
	    public List<int> GetFieldList(string screen)
	    {
		    if (!string.IsNullOrEmpty(screen))
    		{
	    		return ExceptionHandler.InitiateCall(() => new DAL().GetList(screen)); // Slight modification of your code here
		    }
    		else
	    	{
		    	return null; // or whatever fits your needs
		    }
    	}
    }
    public class ExceptionHandler
    {
	    public static T InitiateCall<T>(Func<T> method) 
	    {
    		try
	    	{
		    	return method.Invoke();
		    }
    		catch (Exception ex)
	    	{
		    	//log
			    return default(T);
    		}
    	}
    }
    public class DAL
    {
	    public List<int> GetList(string name)
	    {
		    // I Don't have your classes so I do some dummy stuff
		    return new List<int>() { 6 };
	    }
    }
