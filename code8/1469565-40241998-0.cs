        public static IObservable<T> Separate<T>(this IObservable<T> source, TimeSpan separation)
        {
            return source
                .Timestamp()
                .Scan(
                    new {
                        value = default(T),
                        time = DateTimeOffset.MinValue,
                        delay = TimeSpan.Zero },
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
                .Delay(x => Observable.Timer(x.delay))
                .Select(x => x.value);
        }
