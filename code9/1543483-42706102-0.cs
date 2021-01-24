    public interface IMatcher
    {
	    bool Match(object value);
	    bool Match(string key);
	    bool Match(DateTime key);
	    bool Match(long key);
    }
    public class MyMatcher : IMatcher
    {
	    public bool Match(object value)
    	{
	    	if (value is string)
		    {
			    return Match(value as string);
    		} 
	    	else if (value is DateTime)
		    {
			    return Match(value as DateTime);
    		} 
		    else if (value is long)
    		{
	    		return Match(value as long);
		    }
    		return false;
	    }
    }
