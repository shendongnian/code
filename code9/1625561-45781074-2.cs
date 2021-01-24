	public static class MySingletons
	{
		static SingletonByDefault<Eq> _eq = new SingletonByDefault<Eq>();
		static public Eq Eq
		{
			get
			{
				return _eq.Singlton;
			}
		}
	}
	public class SingletonByDefault<T> where T: new()
	{
		Lazy<T> _singltonWrapped = new Lazy<T>( CreateSingleton );
		static T CreateSingleton()
		{
			return new T();
		}
		public T Singlton
		{
			get
			{
				return _singltonWrapped.Value;
			}
		}
	}
