    public class State /*easily replaced with an F# record */
    {
    	public State(int a, int b)
    	{
    		A = a;
    		B = b;
    	}
    	
    	public int A { get; }
    	public int B { get; }
    }
    /* easily replaced with built-in discriminated unions and pattern matching */
    public static class DiscriminatedUnionExtensions
    {
    	public static IObservable<DiscriminatedUnionClass<T1, T2>> DiscriminatedUnion<T1, T2>(this IObservable<T1> a, IObservable<T2> b)
    	{
    		return Observable.Merge(
    			a.Select(t1 => DiscriminatedUnionClass<T1, T2>.Create(t1)),
    			b.Select(t2 => DiscriminatedUnionClass<T1, T2>.Create(t2))
    		);
    	}
    
    	public static IObservable<TResult> Unify<T1, T2, TResult>(this IObservable<DiscriminatedUnionClass<T1, T2>> source,
    		Func<T1, TResult> f1, Func<T2, TResult> f2)
    	{
    		return source.Select(union => Unify(union, f1, f2));
    	}
    
    	public static TResult Unify<T1, T2, TResult>(this DiscriminatedUnionClass<T1, T2> union, Func<T1, TResult> f1, Func<T2, TResult> f2)
    	{
    		return union.Item == 1
    			? f1(union.Item1)
    			: f2(union.Item2)
    		;
    	}
    }
    
    public class DiscriminatedUnionClass<T1, T2>
    {
    	private readonly T1 _t1;
    	private readonly T2 _t2;
    	private readonly int _item;
    	private DiscriminatedUnionClass(T1 t1, T2 t2, int item)
    	{
    		_t1 = t1;
    		_t2 = t2;
    		_item = item;
    	}
    
    	public int Item
    	{
    		get { return _item; }
    	}
    
    	public T1 Item1
    	{
    		get { return _t1; }
    	}
    
    	public T2 Item2
    	{
    		get { return _t2; }
    	}
    
    	public static DiscriminatedUnionClass<T1, T2> Create(T1 t1)
    	{
    		return new DiscriminatedUnionClass<T1, T2>(t1, default(T2), 1);
    	}
    
    	public static DiscriminatedUnionClass<T1, T2> Create(T2 t2)
    	{
    		return new DiscriminatedUnionClass<T1, T2>(default(T1), t2, 2);
    	}
    }
