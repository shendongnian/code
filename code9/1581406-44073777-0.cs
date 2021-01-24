	interface IConverter
	{
	    Func<string,T> GetConverter<T>(); //the method returned is always strongly typed, so the caller is never responsible for type checking
	}
	
	enum A{AA,AB,AC}
	
	enum B{BA, BB, BC}
	
	class blah : IConverter
	{
		public Func<string,T> GetConverter<T>()
		{
			if(methods.TryGetValue(typeof(T), out var fn))
			{
				return (Func<string,T>)fn;
			}
			throw new NotImplementedException();
		}
		
		public blah()
		{
			set<A>(s => s == "AA" ? A.AA : s == "AB" ? A.AB : A.AC);
			set<B>(s => s == "BA" ? B.BA : s == "BB" ? B.BB : B.BC);
		}
		
		Dictionary<Type, Delegate> methods= new Dictionary<Type, Delegate>();
		
		void set<T>(Func<string,T> fn)
		{
			methods[typeof(T)] = fn;
		}
	}
	
	static void blahah()
	{
	    new blah().GetConverter<A>()("123");
	}
