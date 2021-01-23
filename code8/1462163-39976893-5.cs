	public class LazyDictionary<TKey,TValue>
	{
		private ConcurrentDictionary<TKey, Lazy<TValue>> dictionary = 
		    new ConcurrentDictionary<TKey, Lazy<TValue>>();
		public TValue GetOrAdd(TKey key,Func<TValue> valueGenerator)
		{
			var lazyValue = dictionary.GetOrAdd(key,
				k => new Lazy<TValue>(valueGenerator));
			return lazyValue.Value;
		}
	}
	
	public sealed class ActionDisposable:IDisposable
	{
		private Action action;
		public ActionDisposable(Action action)
		{
			this.action = action;
		}
		public void Dispose()
		{
			var action = this.action;
			if(action != null)
			{
				action();
			}
		}
	}
