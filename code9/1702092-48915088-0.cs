	interface IA
	{
		string Message { get; }
	}
	
	interface IB
	{
		string Message { get; }
	}
	
	class A : B, IA
	{
		string IA.Message {	get { return "Foo"; }}
	}
	
	class B : IB
	{
		string IB.Message { get { return "Bar"; }}
	}
	
	public class Program
	{
		public static void Main()
		{
			IA a = new A();
			IB b = a as IB;
			
			Console.WriteLine(a.Message);
			Console.WriteLine(b.Message);
		}
	}
