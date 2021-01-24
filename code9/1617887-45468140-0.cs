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
                var pattern = new LinkedList<Match<TKey, TSource>>(keys.Select(key => new Match<TKey, TSource>(key)));
                if (pattern.Count == 0)
                {
                    observer.OnCompleted();
                    return Disposable.Empty;
                }
                var sourceSubscription = new SingleAssignmentDisposable();
                Action dispose = () =>
                {
                    sourceSubscription.Dispose();
                    pattern.Clear();
                };
                sourceSubscription.Disposable = source.Subscribe(
                    value =>
                    {
                        try
                        {
                            var key = keySelector(value);
                            var match = pattern.FirstOrDefault(m => !m.IsMatched && keyComparer.Equals(m.Key, key));
                            if (match == null) return;
                            match.MatchedBy = value;
                            while (pattern.First != null && pattern.First.Value.IsMatched)
                            {
                                match = pattern.First.Value;
                                pattern.RemoveFirst();
                                observer.OnNext(match.MatchedBy);
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
        private sealed class Match<TKey, TItem>
        {
            public TKey Key { get; }
            public bool IsMatched { get; private set; }
            private TItem _matchedBy;
            public TItem MatchedBy
            {
                get
                {
                    if (!IsMatched) throw new InvalidOperationException("Not matched.");
                    return _matchedBy;
                }
                set
                {
                    if (IsMatched) throw new InvalidOperationException("Already matched.");
                    IsMatched = true;
                    _matchedBy = value;
                }
            }
            public Match(TKey key)
            {
                Key = key;
            }
        }
    }
