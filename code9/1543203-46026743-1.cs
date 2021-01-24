    public static IObservable<Notification> ThrottledById(this IObservable<Notification> observable)
    {
        return observable.GroupByUntil(x => x.Id, x => Observable.Timer(TimeSpan.FromSeconds(3)))
            .SelectMany(x => x.LastAsync());
    }
