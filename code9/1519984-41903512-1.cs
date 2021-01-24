    struct WriteOnce<T>
    {
    	public T Value { get; }
    
    	public WriteOnce(T input)
    	{
    		Value = input;
        }
    
    	public static implicit operator WriteOnce<T>(T input)
    	{
    		return new WriteOnce<T>(input);
    	}
    }
