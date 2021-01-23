	public abstract class BaseClass<T> where T : BaseClass<T>
	{
		public abstract float Function(T a, T b);
	}
	
	public class Derived : BaseClass<Derived>
	{
		public override float Function(Derived a, Derived b)
		{
			return a.Value + b.Value;
		}
	
		public float Value { get; set; }
	}
