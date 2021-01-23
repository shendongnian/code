    sealed class Assignable<T>
    {
    	private readonly isAssigned;
    	private readonly T value;
    	
    	public Assignable()
    	{
    	}
    	
    	public Assignable(T value)
    	{
    		this.value = value;
    		this.isAssigned = true;
    	}
    
    	public T Value
    	{
    		get
    		{
    			if (!isAssigned) throw new InvalidOperationException();
    			return value;
    		}
    	}
    	
    	public bool IsAssigned
    	{
    		get { return isAssigned; }
    	}
    }
