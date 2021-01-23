	public class A
	{
		public void MethodA()
		{
			Console.WriteLine("MethodA");
		}
		public static void StaticMethodA()
		{
			Console.WriteLine("StaticMethodA");
		}
	}
	public class B
	{
		MethodInfo mv = typeof(A).GetMethod("MethodA");
		MethodInfo smv = typeof(A).GetMethod("StaticMethodA");
		public void CheckA(bool useStatic)
		{
			if (useStatic) smv.Invoke(null, null);
			else mv.Invoke(new A(), null);
		}
	}
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var b = new B();
			b.CheckA(true);
			b.CheckA(false);
		}
	}
