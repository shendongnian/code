	public interface IParameterVisitor
	{
	    void VisitInt(int value);
	    void VisitFloat(float value);
	}
	public interface IParameter
	{
	    void Accept(IParameterVisitor visitor);
	}
