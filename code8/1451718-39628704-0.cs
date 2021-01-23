	public static class ObservableEx
	{
		public static IObservableLookup<K, V> ToLookup<T, K, V>(this IObservable<T> source, Func<T, K> keySelector, Func<T, V> valueSelector, IScheduler scheduler)
		{
			return new ObservableLookup<T, K, V>(source, keySelector, valueSelector, scheduler);
		}
		
		internal class ObservableLookup<T, K, V> : IDisposable, IObservableLookup<K, V>
		{
			private IDisposable _subscription = null; 
			private readonly Dictionary<K, ReplaySubject<V>> _lookups = new Dictionary<K, ReplaySubject<V>>();
			
			internal ObservableLookup(IObservable<T> source, Func<T, K> keySelector, Func<T, V> valueSelector, IScheduler scheduler)
			{
				_subscription = source.ObserveOn(scheduler).Subscribe(
					t => this.GetReplaySubject(keySelector(t)).OnNext(valueSelector(t)),
					ex => _lookups.Values.ForEach(rs => rs.OnError(ex)),
					() => _lookups.Values.ForEach(rs => rs.OnCompleted()));
			}
			
			public void Dispose()
			{
				if (_subscription != null)
				{
					_subscription.Dispose();
					_subscription = null;
					_lookups.Values.ForEach(rs => rs.Dispose());
					_lookups.Clear();
				}
			}
			
			private ReplaySubject<V> GetReplaySubject(K key)
			{
				if (!_lookups.ContainsKey(key))
				{
					_lookups.Add(key, new ReplaySubject<V>());
				}
				return _lookups[key];
			}
			
			public IObservable<V> this[K key]
			{
				get
				{
					if (_subscription == null) throw new ObjectDisposedException("ObservableLookup");
					return this.GetReplaySubject(key).AsObservable();
				}
			}
		}
	}
	
	public interface IObservableLookup<K, V> : IDisposable
	{
		IObservable<V> this[K key] { get; }
	}
