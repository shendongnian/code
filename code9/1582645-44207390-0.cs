    class BasicConcurrentSet<T> : IEnumerable<T> {
        private readonly ConcurrentDictionary<T, byte> _items = new ConcurrentDictionary<T, byte>();
        public void Add(T item) {
            _items.TryAdd(item, 0);
        }
        public void Remove(T item) {
            byte tmp;
            _items.TryRemove(item, out tmp);
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator() {
            foreach (var kv in _items) {
                yield return kv.Key;
            }
        }
    }
