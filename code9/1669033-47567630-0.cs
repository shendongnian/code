	public class Program
	{
		public static void Main()
		{
			var foo = new Foo();
			
			if(foo == null)
			{
			}
			
			if(null == foo)
			{
			}
		}
	}
	public class Foo
	{
		public static bool operator ==(Foo a, Foo b)
		{
			Console.WriteLine("Foo operator == called");
			return ReferenceEquals(a, b);
		}
		public static bool operator !=(Foo a, Foo b)
		{
			Console.WriteLine("Foo operator != called");
			return !(a == b);
		}
		public override bool Equals(object obj)
		{
			Console.WriteLine("Foo Equals() called");
			return ReferenceEquals(this, obj);
		}
		public override int GetHashCode()
		{
			Console.WriteLine("Foo GetHashCode() called");
			return base.GetHashCode();
		}
	}
