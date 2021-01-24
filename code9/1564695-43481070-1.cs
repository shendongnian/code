    public class CastingTransformer<TSource, TResult> : Transformer<TSource, TResult>
    {
    	public TResult Transform(TSource original)
    	{
    		return (TResult)(object)original;
    	}
    }
    public Controller() : this(new CastingTransformer<TEntity, TResult>()) { }
