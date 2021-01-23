		public class Base
		{
			public Base()
			{
				Console.WriteLine(
					new StackTrace()
						.GetFrame(1)
						.GetMethod()
						.DeclaringType
						.Assembly
						.FullName);
			}
		}
		
		public class Derived : Base
		{
			public Derived() {        }
		}
