    public static class Base
    {
	    private static string Field = "field";
	
	    public class Base2<T>
	    {
            public Base2()
		    {
			    // Field is accessible here, but is the same across all generic classes
			    Console.WriteLine(Field);
		    }
	    }
    }
    public class BaseChild : Base.Base2<string>
    {
	    public BaseChild()
	    {
		    //Field is not accessible here, and I don't really want it to be
		    //Console.WriteLine(Field);
	    }
    }
