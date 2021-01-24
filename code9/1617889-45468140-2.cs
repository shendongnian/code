    public static class MyExtensions
    {
        public static IObservable<TSource> MatchByKeys<TSource, TKey>(this IObservable<TSource> source, IEnumerable<TKey> keys, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keys == null) throw new ArgumentNullException(nameof(keys));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (keyComparer == null) keyComparer = EqualityComparer<TKey>.Default;
            return Observable.Create<TSource>(observer =>
            {
                var pattern = new LinkedList<SingleAssignment<TSource>>();
                var matchesByKey = new Dictionary<TKey, LinkedList<SingleAssignment<TSource>>>(keyComparer);
                foreach (var key in keys)
                {
                    var match = new SingleAssignment<TSource>();
                    pattern.AddLast(match);
                    LinkedList<SingleAssignment<TSource>> matches;
                    if (!matchesByKey.TryGetValue(key, out matches))
                    {
                        matches = new LinkedList<SingleAssignment<TSource>>();
                        matchesByKey.Add(key, matches);
                    }
                    matches.AddLast(match);
                }
                if (pattern.First == null)
                {
                    observer.OnCompleted();
                    return Disposable.Empty;
                }
                var sourceSubscription = new SingleAssignmentDisposable();
                Action dispose = () =>
                {
                    sourceSubscription.Dispose();
                    pattern.Clear();
                    matchesByKey.Clear();
                };
                sourceSubscription.Disposable = source.Subscribe(
                    value =>
                    {
                        try
                        {
                            var key = keySelector(value);
                            LinkedList<SingleAssignment<TSource>> matches;
                            if (!matchesByKey.TryGetValue(key, out matches)) return;
                            matches.First.Value.Value = value;
                            matches.RemoveFirst();
                            if (matches.First == null) matchesByKey.Remove(key);
                            while (pattern.First != null && pattern.First.Value.HasValue)
                            {
                                var match = pattern.First.Value;
                                pattern.RemoveFirst();
                                observer.OnNext(match.Value);
                            }
                            if (pattern.First != null) return;
                            dispose();
                            observer.OnCompleted();
                        }
                        catch (Exception ex)
                        {
                            dispose();
                            observer.OnError(ex);
                        }
                    },
                    error =>
                    {
                        dispose();
                        observer.OnError(error);
                    },
                    () =>
                    {
                        dispose();
                        observer.OnCompleted();
                    });
                return Disposable.Create(dispose);
            });
        }
        private sealed class SingleAssignment<T>
        {
            public bool HasValue { get; private set; }
            private T _value;
            public T Value
            {
                get
                {
                    if (!HasValue) throw new InvalidOperationException("No value has been set.");
                    return _value;
                }
                set
                {
                    if (HasValue) throw new InvalidOperationException("Value has alredy been set.");
                    HasValue = true;
                    _value = value;
                }
            }
        }
    }
