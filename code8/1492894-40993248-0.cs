    class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
    	IEnumerable<TElement> elements;
    	public Grouping(TKey key, IEnumerable<TElement> elements)
    	{
    		this.Key = key;
    		this.elements = elements;
    	}
    	public TKey Key { get; }
    	public IEnumerator<TElement> GetEnumerator() => elements.GetEnumerator();
    	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public static class Grouping
    {
    	public static IGrouping<TKey, TElement> Create<TKey, TElement>(TKey key, IEnumerable<TElement> elements) =>
    		new Grouping<TKey, TElement>(key, elements);
    }
