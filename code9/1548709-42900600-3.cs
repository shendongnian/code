	public class A : Base
	{
		public override void foo()
		{
			if(!Base.isFooCalled)
				base.foo();
			Debug.WriteLine("A foo()");
		}
	}
