    using System;
    public class Program
    {
	 public class Parent
	 {
		
		public virtual string item{get;set;}
	 }
	 public class Child : Parent
	 {
	
		public new string item
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}
		
	}
	public static void ConsoleWrite(Parent pitem)
	{
		Console.Write(pitem.item);
	}
	public static void Main()
	{
		ConsoleWrite(new Child(){item = "foo"});
	}
}
 
