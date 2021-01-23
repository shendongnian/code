    public static class SomeStaticClass
    {
    	public static Validator<T,TKey> CreateValidator<T,TKey>(this IEnumerable<T> list, Func<T,TKey> keyselector)
    	{
    		return new Validator<T,TKey>(keyselector);
    	}
    }
