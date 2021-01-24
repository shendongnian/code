	public class C : B
	{
		public int SomeMethod()
		{
			SomeClass stub = this.Field;
			FSharpFunc<Unit, int> magic = new $Library1.magic@11(stub);
			return magic.Invoke(null);
		}
    }
