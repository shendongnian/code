    using System;
					
    public class Program
    {
	public static void Main()
	{
		Test();
	}
	private static void Test(Type t = null)
	{
		
		if(t==null)
		{
			t=typeof(Object);
			Console.WriteLine(t.Name);
		}
	}
    }
