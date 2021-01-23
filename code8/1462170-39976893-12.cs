	public class LazyDictionary<TKey,TValue>
	{
        //here we use Lazy<TValue> as the value in the dictionary
        //to guard against the fact the the initializer function
        //in ConcurrentDictionary.AddOrGet *can*, under some conditions, 
        //run more than once per key, with the result of all but one of 
        //the runs being discarded. 
        //If this happens, only uninitialized
        //Lazy values are discarded. Only the Lazy that actually 
        //made it into the dictionary is materialized by accessing
        //its Value property.
		private ConcurrentDictionary<TKey, Lazy<TValue>> dictionary = 
		    new ConcurrentDictionary<TKey, Lazy<TValue>>();
		public TValue GetOrAdd(TKey key, Func<TValue> valueGenerator)
		{
			var lazyValue = dictionary.GetOrAdd(key,
				k => new Lazy<TValue>(valueGenerator));
			return lazyValue.Value;
		}
	}
