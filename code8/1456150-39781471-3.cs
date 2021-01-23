	public static void Main()
	{
		try
		{
			ParentMethod();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
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
		throw new CompileObjectException(new CustomObject {Scope = "C"}, "Child Message");
	}
