    public class DefaultValueGenerator<T>
    {
    	public virtual T Default()
    	{
    		return default(T);
    	}
    }
    
    public class StringValueGenerator : DefaultValueGenerator<string>
    {
    	public override string Default()
    	{
    		return "";
    	}
    }
    public static T SafeGetValue<T>(SqlDataReader dr, string columnName, 
        DefaultValueGenerator<T> defaultGenerator)
    {
        //snip
        returnValue = defaultGenerator.Default();
    }
