    public static IObservable<T> Separate<T>(this IObservable<T> source, TimeSpan separation, IScheduler scheduler)
    {
        return Observable.Create<T>(
            observer =>
            {
                var timedSource = source
                    .Timestamp(scheduler)
                    .Scan(
                        new
                        {
                            value = default(T),
                            time = DateTimeOffset.MinValue,
                            delay = TimeSpan.Zero
                        },
                        (acc, item) =>
                        {
                            var time =
                                item.Timestamp - acc.time >= separation
                                ? item.Timestamp
                                : acc.time.Add(separation);
                            return new
                            {
                                value = item.Value,
                                time,
                                delay = time - item.Timestamp
                            };
                        })
                    .Publish();
    
                var combinedSource = Observable.Merge(
                    timedSource.Where(x => x.delay == TimeSpan.Zero),
                    timedSource.Where(x => x.delay > TimeSpan.Zero).Delay(x => Observable.Timer(x.delay, scheduler))
                );
    
                return new CompositeDisposable(
                    combinedSource.Select(x => x.value).Subscribe(observer),
                    timedSource.Connect()
                );
            }
        );
    }
