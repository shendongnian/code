    public class MyEventStoreConsumer
    {
        private static readonly Func<Task<IEventStoreConnection>> getConnection;
    
        static MyEventStoreConsumer()
        {
            var eventStore = EventStoreConnection.Create(...);
            var connection = new AsyncLazy<IEventStoreConnection>(async () =>
            {
                await eventStore.ConnectAsync().ConfigureAwait(false);
                return eventStore;
            });
            getConnection = () => connection.GetValueAsync();
        }
    }
