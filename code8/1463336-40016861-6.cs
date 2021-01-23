    static void Main(string[] args)    {
	    BAL b = new BAL();
	    var ll = b.GetFieldList("xxxxyyyy");
    }
    public class BAL
    {
	    public List<Fields> GetFieldList(string screen)
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
	    public  List<Fields> GetList(string name)
        {
            VipreDBDevEntities context = new VipreDBDevEntities();
            return context.Database.SqlQuery<Fields>("SCREEN_FIELDS_SELECT @SCREEN_NAME", name).ToList();
        }
    }
