	public class Program
	{
		protected Program()
		{
			// Do something.
		}
		
		public static Program Create()
		{
			// 100% Allowed.
			return new Program();
		}
		
		public void DoSomething()
		{
			
		}
	}
	public static class AnotherClass
	{
		public static Program CreateProgram()
		{
			// Not allowed since it's protected.
			return new Program();
		}
	}
	
	public class SubProgram : Program
	{
		public static Program Create()
		{
			// Allowed since SubProgram inherits from Program and Program's constructor is protected (instead of private).
			return new Program();
		}
	}
	Program.Create(); 				// Can be called since Create is a static function.
	Program.DoSomething() 			// Can't be called because an instance has not been instantiated.
	var test = Program.Create();
	test.DoSomething(); 			// Can be called since there is now an instance of Program (i.e. 'test').
	AnotherClass.CreateProgram(); 	// Can't be called since Program's constructor is protected.
    SubProgram.Create();            // Can be called since SubProgram inherits from Program.
