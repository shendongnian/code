	public abstract class Parameter<T> : IParameter
	{
	    protected T value;
	    public virtual T Value
	    {
	        get { return value; }
	        set { this.value = value; }
	    }
	    protected Parameter(T startingValue)
	    {
	        value = startingValue;
	    }
	    public abstract void Accept(IParameterVisitor visitor);
	}
