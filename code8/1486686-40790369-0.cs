    public static IObservable<RedisValue> WhenMessageReceived(ISubscriber subscriber, RedisChannel channel)
    {
        return Observable.Create<RedisValue>(async (obs, ct) =>
        {
            await subscriber.SubscribeAsync(channel, (_, message) =>
            {
                obs.OnNext(message);
            }).ConfigureAwait(false);
    
            return Disposable.Create(() => subscriber.Unsubscribe(channel));
        });
    }
