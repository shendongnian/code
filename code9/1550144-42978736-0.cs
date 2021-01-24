	using System;
	using System.Text.RegularExpressions;
	public interface IA
	{
		string Value { get; set; }
		
		T Cast<T>() where T : class, IA;
	}
	public abstract class ABase : IA
	{
		public virtual string Value { get; set; }
		
		public T Cast<T>() where T : class, IA
		{
			return this as T;
		}
	}
	public class A : ABase
	{
		// redundant, not really needed
		public override String Value { get; set; }
	}
	public class A2 : ABase
	{
		// redundant, not really needed
		public override String Value { get; set; }
		public String Value2 { get; set; }
	}
	public class B
	{
		public IA Prop { get; set; }
	}
	public class C : B
	{
		public C()
		{
			Prop = new A();
			Prop.Value = "test C";
		}
	}
	public class C2 : B
	{
		public C2()
		{
			Prop = new A2();
			Prop.Value = "test C2";
			Prop.Cast<A2>().Value2 = "test C2 Value2";
		}
	}
	public static class D
	{
		public static string GetDynamicProp(dynamic item)
		{
			Console.WriteLine(item.GetType().FullName);
			Console.WriteLine(item.Prop.GetType().FullName);
			return item.Prop.Value;
		}
		public static string GetProp<T>(T item) where T : B
		{
			Console.WriteLine(item.GetType().FullName);
			Console.WriteLine(item.Prop.GetType().FullName);
			return item.Prop.Value;
		}
	}
	public class Program
	{
		
		public static void Main()
		{
			var test = new C();
			
			Console.WriteLine(test.Prop.Value);        // test C
			
			Console.WriteLine(D.GetDynamicProp(test)); // test C
			
			Console.WriteLine(D.GetProp(test)); 
			var test2 = new C2();
			
			Console.WriteLine(test2.Prop.Value);        // test C2
			
			Console.WriteLine(D.GetDynamicProp(test2)); // test C2
			
			Console.WriteLine(D.GetProp(test2)); 		// test C2
			Console.WriteLine(D.GetProp(test2)); 		// test C2
			
			Console.WriteLine(test2.Prop.Cast<A2>().Value); 		// test C2
			Console.WriteLine(test2.Prop.Cast<A2>().Value2); 		// test C2 Value2
		
		}
	}
