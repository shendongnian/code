    public static class RxExtensions
    {
        /// <summary>
        /// A cache that keeps distinct elements where the elements are replaced by the latest.
        /// </summary>
        /// <typeparam name="T">The type of the result</typeparam>
        /// <typeparam name="TKey">The type of the selector key for distinct results.</typeparam>
        /// <param name="newElements">The sequence of new elements.</param>
        /// <param name="seedElements">The elements when the cache is started.</param>
        /// <param name="keySelector">The replacement to select distinct elements in the cache.</param>
        /// <returns>The cache contents upon first call and changes thereafter.</returns>
        public static IConnectableObservable<T> Cache<T, TKey>(this IObservable<T> newElements, IEnumerable<T> seedElements, Func<T, TKey> keySelector)
        {
            return new Cache<TKey, T>(newElements, seedElements, keySelector);
        }
    }
    public class Cache<TKey, T> : IConnectableObservable<T>
    {
        private class State
        {
            public ImmutableDictionary<TKey, T> Cache { get; set; }
            public T Value { get; set; }
        }
        private readonly IConnectableObservable<State> _source;
        private readonly IObservable<T> _observable;
        public Cache(IObservable<T> newElements, IEnumerable<T> seedElements, Func<T, TKey> keySelector)
        {
            var agg = new State { Cache = seedElements.ToImmutableDictionary(keySelector), Value = default(T) };
            _source = newElements
                // Use the Scan operator to update the dictionary of values based on key and use the anonymous tuple to pass this and the current item to the next operator
                .Scan(agg, (tuple, item) => new State { Cache = tuple.Cache.SetItem(keySelector(item), item), Value = item })
                // Ensure we always have at least one item
                .StartWith(agg)
                // Share this single subscription to the above with all subscribers
                .Publish();
            _observable = _source.Publish(source =>
                    // ... concatting ...
                    Observable.Concat(
                        // ... getting a single collection of values from the cache and flattening it to a series of values ...
                        source.Select(tuple => tuple.Cache.Values).Take(1).SelectMany(values => values),
                        // ... and the returning the values as they're emitted from the source
                        source.Select(tuple => tuple.Value)
                    )
                );
        }
        public IDisposable Connect()
        {
            return _source.Connect();
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return _observable.Subscribe(observer);
        }
    }
