	void Main()
	{
		new Generics<string>();
		new Generics<int>();
	}
	
	class Generics<T>
	{
		public Generics()
		{
			if(typeof(T) == typeof(int)) InitForInt();
		}
		
		private void InitForInt()
		{
			Console.WriteLine("Int!");		
		}
		// create a constructor which will get called only for int
	}
