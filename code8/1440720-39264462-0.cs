    using System;
					
    public class Program
    {
	public static void Main()
	{
		DateTime time = DateTime.Now; 
		
		Console.WriteLine(String.Format("{0:yy-dd-mm}", time));
	}
    }
