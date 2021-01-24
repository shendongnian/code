    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var students = new List<Tuple<string, int>>();
    		
    		students.Add(new Tuple<string, int>("test", 10));
    		students.Add(new Tuple<string, int>("test", 10));
    		
    		Console.Write(students.Max(t => t.Item2));
    	}
    }
