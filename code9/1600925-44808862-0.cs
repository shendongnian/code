	abstract class Foo
	{
		public virtual void MyMethod()
		{
			Console.WriteLine("DoOneThing");
		}
	}
	
	class MegaFoo : Foo
	{
		public override void MyMethod()
		{
			base.MyMethod(); // call Foo.MyMethod
			Console.WriteLine("DoAnotherThing");
		}
	}
