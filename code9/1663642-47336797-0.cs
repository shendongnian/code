    internal class NumericLimit<TValue> where TValue : IComparable
    {
		internal bool IsDefined { get; }
    	public NumericLimit(TValue min, TValue max)
    	{
    		this.Max = max;
    		this.Min = min;
    		IsDefined = true;
    	}
    
    	private NumericLimit()
    	{
    		IsDefined = false;
    	}
    
    	public static NumericLimit<TValue> Undefined()
    	{
    		return new NumericLimit<TValue>();
    	}
        // ...
    }
