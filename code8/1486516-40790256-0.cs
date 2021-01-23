    class QueryThrottler<TQuery, TResult> : IQueryExecuter<TQuery, TResult>
    {
        // do not lock on external objects
        class QueryObject
        {
            public TQuery Query { get; set; }
        }
        readonly IQueryExecuter<TQuery, TResult> _inner;
        readonly ConcurrentDictionary<TQuery, QueryObject> _queries;
        public QueryThrottler(IQueryExecuter<TQuery, TResult> inner)
        {
            _queries = new ConcurrentDictionary<TQuery, QueryObject>();
            _inner = inner;
        }
        public TResult Execute(TQuery query)
        {
            // if it is on cache return the result
            TResult result;
            if (!IsCached(query, out result))
            {
                // otherwise lock other threads
                // on the same query
                var queryObject = _queries.GetOrAdd(query, k => new QueryObject() { Query = k });
                lock (queryObject)
                {
                    // double check it is not cached already
                    if (!IsCached(query, out result))
                    {
                        result = _inner.Execute(queryObject.Query);
                        PopulateCache(query, result);
                    }
                }
            }
            return result;
        }
        private void PopulateCache(TQuery query, TResult result)
        {
            // TODO
        }
        private bool IsCached(TQuery query, out TResult result)
        {
            // go to redis and check if the query is cached
            result = default(TResult);
            return false;
        }
    }
