    public class ThreadsafeService3
    {
        private readonly ConcurrentDictionary<string, ThreadSafeItem3> _storage =
            new ConcurrentDictionary<string, ThreadSafeItem3>();
        public void AddOrUpdate(string name)
        {
            _storage.AddOrUpdate(name, _ => new ThreadSafeItem3(), (_, oldValue) => oldValue.Increment());
        }
        public void Analyze()
        {
            foreach (var pair in _storage)
            {
                long ticks = pair.Value.ModifiedTicks;
                //Note, the value may have been updated since we checked; 
                //you've said you don't care and it's okay for a newer item to be removed here if it loses the race.
                if (isTooOld(ticks))
                    _storage.TryRemove(pair.Key, out _);  
            }
        }
    }
    public class ThreadSafeItem3
    {
        public ThreadSafeItem3()
        {
            Counter = 0;
        }
        private ThreadSafeItem3(int counter)
        {
            Counter = counter;
        }
        public ThreadSafeItem3 Increment()
        {
            return new ThreadSafeItem3(Counter + 1);
        }
        public long ModifiedTicks { get; } = DateTime.Now.Ticks;
        public int Counter { get; }
    }
