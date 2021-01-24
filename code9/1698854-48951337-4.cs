    using System;
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class MyAttribute : Attribute {
    	public MyAttribute(params object[] x){}
    }
    public class Program
    {
    	[MyAttribute()]
    	[MyAttribute(new int[0])]
    	[MyAttribute(new string[0])] // ERROR
    	[MyAttribute(new object[0])]
    	[MyAttribute(new string[0], new string[0])]  
    	public static void Main() { }
    }
