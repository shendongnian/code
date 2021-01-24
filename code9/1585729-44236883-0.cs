	public abstract class ParentClass
	{
		public virtual void Method()
		{
			if (true)
			{
				// do something
				Console.WriteLine("Parent Method should stop it's child!");
				throw new Exception();
			}
		}
	}
	public class ChildClass : ParentClass
	{
		public override void Method()
		{
			try
			{
				base.Method();
			}
			catch (Exception)
			{
				return;
			}
			Console.WriteLine("Should't be run");
		}
	}
