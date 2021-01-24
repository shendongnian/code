	public class FloatParameter : Parameter<float>
	{
	    public FloatParameter(float startingValue) : base(startingValue) { }
	    public override void Accept(IParameterVisitor visitor)
	    {
	        visitor.VisitFloat(this.value);
	    }
	}
	public class IntParameter : Parameter<int>
	{
	    public override int Value
	    {
	        get { return value; }
	        set { this.value = value > 100 ? 100 : value; }
	    }
	    public override void Accept(IParameterVisitor visitor)
	    {
	        visitor.VisitInt(this.value);
	    }
	    public IntParameter(int startingValue) : base(startingValue) { }
	}
