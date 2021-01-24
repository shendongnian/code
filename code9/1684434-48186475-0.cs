	void Main()
	{
		var objA = new Base {
			Prop = "test"
		};
		
		var objB = new Derived {
			Prop = 42
		};
	}
	public class Base
    {
		public virtual string Prop { get; set; }
	}
	public class Derived : Base
	{
		public new int Prop { get; set; }
	}
