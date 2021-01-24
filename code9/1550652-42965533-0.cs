	class EvenMoreBase
	{
	    protected static readonly string Field = "field";
	}
	class Base<T> : EvenMoreBase
	{
	    public Base()
	    {
		    Console.WriteLine(Field);
	    }
	}
	class BaseChild : Base<string>
	{
	    public BaseChild()
	    {
		Console.WriteLine(Field);
	    }
	}
