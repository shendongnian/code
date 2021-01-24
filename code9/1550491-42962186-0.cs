    public static IEnumerable<T> Unfold<T, TState>(TState init, Func<TState, T> gen)
    {
    	var liftF = new Converter<TState, Microsoft.FSharp.Core.FSharpOption<Tuple<T, TState>>>(x =>
    	{
    		var r = gen(x);
    		if (r == null)
    		{
    			return Microsoft.FSharp.Core.FSharpOption<Tuple<T, TState>>.None;
    		}
    		else
    		{
    			return Microsoft.FSharp.Core.FSharpOption<Tuple<T, TState>>.Some(Tuple.Create(r, x));
    		}
    	});
    
    	var ff = Microsoft.FSharp.Core.FSharpFunc<TState, Microsoft.FSharp.Core.FSharpOption<Tuple<T, TState>>>.FromConverter(liftF);
    	return Microsoft.FSharp.Collections.SeqModule.Unfold<TState, T>(ff, init);
    }
    
    public static IEnumerable<T> Unfold<T>(T source, Func<T, T> func)
    {
    	return Unfold<T>(source, func);
    }
