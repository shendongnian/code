	public abstract class Deal<D, I> where D : Deal<D, I> where I : Inventory<D, I>
	{
		public I Vehicle { get; set; }
	
		public abstract D Get(string id);
	}
	
	public abstract class Inventory<D, I> where D : Deal<D, I> where I : Inventory<D, I>
	{ }
	
	public class Cash : Deal<Cash, Car>
	{
		public override Cash Get(string id)
		{
			return new Cash() { Vehicle = new Car() };
		}
	}
	
	public class Car : Inventory<Cash, Car>
	{ }
