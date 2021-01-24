    class Storage<T>
    {
        private AsyncLocal<ImmutableStack<T>> stackHolder = new AsyncLocal<ImmutableStack<T>>();
    
        public IDisposable Push(T item)
        {
            var bookmark = new StorageBookmark<T>(this);
    
            stackHolder.Value = (stackHolder.Value ?? ImmutableStack<T>.Empty).Push(item);
            return bookmark;
        }
    
        private class StorageBookmark<TInner> : IDisposable
        {
            private Storage<TInner> owner;
            private ImmutableStack<TInner> snapshot;
            private Thread boundThread;
            private readonly object id;
    
            public StorageBookmark(Storage<TInner> owner)
            {
                id = new object();
                this.owner = owner;
                this.snapshot = owner.stackHolder.Value;
                CallContext.LogicalSetData("AsyncStorage", id);
            }
    
            public void Dispose()
            {
                if (CallContext.LogicalGetData("AsyncStorage") != id)
                    throw new InvalidOperationException("Bookmark crossed async context boundary");
                owner.stackHolder.Value = snapshot;
            }
        }
    }
    
    public class Program
    {
        static void Main()
        {
            DoesNotThrow().Wait();
            Throws().Wait();
        }
    
        static async Task DoesNotThrow()
        {
            var storage = new Storage<string>();
    
            using (storage.Push("hello"))
            {
                await Task.Yield();
            }
        }
    
        static async Task Throws()
        {
            var storage = new Storage<string>();
    
            var disposable = storage.Push("hello");
    
            using (ExecutionContext.SuppressFlow())
            {
                Task.Run(() => { disposable.Dispose(); }).Wait();
            }
        }
    }
