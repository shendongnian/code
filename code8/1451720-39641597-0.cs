    public sealed class RouteData<TKey, TSource>
    {
        private IConnectableObservable<IGroupedObservable<TKey, TSource>> myRoutes;
        public RouteData(IObservable<TSource> source, Func<TSource, TKey> keySelector)
        {
            this.myRoutes = source.GroupBy(keySelector).Replay();
        }
        public IDisposable Connect()
        {
            return this.myRoutes.Connect();
        }
        public IObservable<TSource> Get(TKey id)
        {
            return myRoutes.FirstAsync(e => e.Key.Equals(id)).Merge();
        }
    }
    public static class myExtension
    {
        public static RouteData<TKey, TSource> RouteData<TKey, TSource>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return new RouteData<TKey, TSource>(source, keySelector);
        }
    }
