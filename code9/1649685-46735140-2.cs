    public class SortedMultiValue<TKey, TValue> : IEnumerable<TValue>
    {
    	private SortedDictionary<TKey, List<TValue>> _data;
    
    	public SortedMultiValue()
    	{
    		_data = new SortedDictionary<TKey, System.Collections.Generic.List<TValue>>();
    	}
	    public void Clear()
	    {
		    _data.Clear();
	    }
    
    	public void Add(TKey key, TValue value)
    	{
    		if (!_data.TryGetValue(key, out List<TValue> items))
    		{
    			items = new List<TValue>();
    			_data.Add(key, items);
    		}
    		items.Add(value);
    	}
    
    	public IEnumerable<TValue> Get(TKey key)
    	{
    		if (_data.TryGetValue(key, out List<TValue> items))
    		{
    			return items;
    		}
    		throw new KeyNotFoundException();
    	}
    
    	public IEnumerator<TValue> GetEnumerator()
    	{
    		return CreateEnumerable().GetEnumerator();
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return CreateEnumerable().GetEnumerator();
    	}
    
    	IEnumerable<TValue> CreateEnumerable()
    	{
    		foreach (IEnumerable<TValue> values in _data.Values)
    		{
    			foreach (TValue value in values)
    			{
    				yield return value;
    			}
    		}
    	}
    }
