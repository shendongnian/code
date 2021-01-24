    class Data
    {
    }
    class Proxy
    {
	    public virtual T Get<T>()
    	{
	    	return default(T);
    	}
    }
    class Stub : Proxy
    {
    	private Data x = default(Data);
	
	    public override Data Get<Data>()
    	{
	    	return x;
    	}
    }
