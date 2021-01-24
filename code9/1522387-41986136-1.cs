	public abstract class Characteristic<T> where T : IModifiable<T>
	{
		private T _value;
		public T Value
		{
			get { return _value; }
			set { _value = value; }
		}
	}
