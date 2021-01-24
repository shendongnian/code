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
			if(methods.TryGetValue(typeof(T), out var fn)) //side note, out var fn will not work in older visual studio versions. In that case declare fn before this line
				return (Func<string,T>)fn; //the set<T> method ensures that this conversion is safe
			throw new NotImplementedException(); 
		}
		
		public blah()
		{
			set<A>(s => s == "AA" ? A.AA : s == "AB" ? A.AB : A.AC); //copied from the example. Enum.Parse could perhaps be used instead
			set<B>(s => s == "BA" ? B.BA : s == "BB" ? B.BB : B.BC);
		}
		
		Dictionary<Type, Delegate> methods= new Dictionary<Type, Delegate>(); // Delegate can be used as a type to handle all lambda's. It's the implementers responsibility to handle with care. Something like the set<T> helper method is recommended
		
		void set<T>(Func<string,T> fn) //helper method to assign the strongly typed methods to the specific type
		{
			methods[typeof(T)] = fn;
		}
	}
	
	static void blahah()
	{
	    new blah().GetConverter<A>()("123");
	}
