	interface IFoo
	{
		string P {get;}
	}
	
	class Base: IFoo
	{
		string IFoo.P 
		{
			get { return "Base"; }
		}
	}
	
	class Derived: Base, IFoo
	{
		string IFoo.P 
		{
			get { return "Derived"; }
		}
	}
