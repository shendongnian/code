    public class Holder<T>
    {
    	private Holder(T value)
    	{
    		WasSuccessful = true;
    		Value = value;
    	}
    
    	private Holder(int errorCode)
    	{
    		WasSuccessful = false;
    		ErrorCode = errorCode;
    	}
    
    	public bool WasSuccessful { get; }
    	public T Value { get; }
    	public int ErrorCode { get; }
    
    	public static Holder<T> Success(T value)
    	{
    		return new Holder<T>(value);
    	}
    
    	public static Holder<T> Fail(int errorCode)
    	{
    		return new Holder<T>(errorCode);
    	}
    }
