	public interface IA<T>
	{
	    int Foo(T otherType);
	}
	
	class A : IA<A>
	{
	    public int Foo(A otherType)
	    {
			return 42;
	    }
	}
