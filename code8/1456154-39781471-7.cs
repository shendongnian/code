	public static void Main()
	{
		try
		{
			ParentMethod();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);  // implicitly calls e.ToString()
		}
		
	}
	
	public static void ParentMethod()
	{
		try
		{
			ChildMethod();
		}
		catch (Exception e)
		{
			throw new CompileObjectException(new CustomObject {Scope = "P"}, "Parent Message", e);
		}
	}
	
	public static void ChildMethod()
	{
		try
		{
			YetAnotherChild();
		}
		catch (Exception e)
		{
		    throw new CompileObjectException(new CustomObject {Scope = "C"}, "Child Message", e);
		}
	}
	
	public static void YetAnotherChild()
	{
        throw new CompileObjectException(new CustomObject {Scope = "C2"}, "Another Child Message");
    }
