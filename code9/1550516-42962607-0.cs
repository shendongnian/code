    using System;
    public static class Outer
    {
    	private interface IPrivates
    	{
    		string Name { set; }
    	}
    	public readonly static Inner TheInner = new Inner();
    	private readonly static IPrivates TheInnerPrivates = TheInner;
    	public class Inner : IPrivates
    	{
    		public string Name { get; private set; }		
    		string IPrivates.Name { set { this.Name = value; } }
    	}
    	public static void DoIt()
    	{
    		TheInnerPrivates.Name = "abc";
    	}
    }  
    public class Program
    {
    	public static void Main()
    	{
    		Outer.DoIt();
    		Console.WriteLine(Outer.TheInner.Name);
    	}
    }
