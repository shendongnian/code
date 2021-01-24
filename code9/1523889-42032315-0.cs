    interface IWithKey<T> {
        public T Key { get; set; }
    }
    static class DictExtensions {
        public static TVal GetorCreate<TKey,TVal>(this IDictionary<TKey,TVal> d, TKey key) where TVal : new(), IWithKey<TKey> {
            TVal res;
            if (!d.TryGetValue(key, out res)) {
                res = new TVal();
                res.Key = key;
                d.Add(key, res);
            }
            return res;
        }
    }
