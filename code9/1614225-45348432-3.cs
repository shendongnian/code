	public class C : B
	{
		public int SomeMethod()
		{
			SomeClass stub = this.Field;
			FSharpFunc<Unit, int> d = new d@11(stub);
			return d.Invoke(null);
		}
    }
