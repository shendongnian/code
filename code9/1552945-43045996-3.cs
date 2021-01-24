	public class MyVisitor : IParameterVisitor
	{
	    public void VisitInt(int value)
	    {
	        Console.WriteLine($"Visiting an int: {value}");
	    }
	    public void VisitFloat(float value)
	    {
	        Console.WriteLine($"Visiting a float: {value}");
	    }
	}
