    internal class magic@11 : FSharpFunc<Unit, int>
	{
		public C @this;
		internal magic@11(C @this)
		{
			this.@this = @this;
		}
		public override int Invoke(Unit unitVar0)
		{
            // this would be an attempt to access the protected field 
            // if the compiler allowed it.
			return @this.Field.SomeMoreMagic();  
		}
	}
	
	public class C : B
	{
		public int SomeMethod()
		{
			FSharpFunc<Unit, int> magic = new magic@11(this);
			return magic.Invoke(null);
		}
	}
