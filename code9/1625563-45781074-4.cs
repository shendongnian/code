	public static class MySingletons
	{
		static SingletonByLazy<Eq> _eq = new SingletonByLazy<Eq>();
		static public Eq Eq
		{
			get
			{
				return _eq.Singlton;
			}
		}
	}
	public class SingletonByLazy<T> where T: new()
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
