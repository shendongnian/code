    // Removed the static modifier
	public abstract class A
	{
		public string MyMethod()
		{
			return "a";
		}
	}
    // Made B inherit directly from A
	public class B : A
	{
		public void AnotherMethod()
		{
			var S1 = base.MyMethod(); //base technically isn't required
		}
	}
