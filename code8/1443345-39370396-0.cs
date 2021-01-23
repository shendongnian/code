    public class SilentDictionary<TKey, TValue> : IDictionary<TKey, TValue>
            where TValue : class, new()
        {
            protected IDictionary<TKey, TValue> Dictionary;
    
            public SilentDictionary()
            {
                Dictionary = new Dictionary<TKey, TValue>();
            }
    
            public TValue this[TKey key]
            {
                get
                {
                    TValue item;
                    if (Dictionary.TryGetValue(key, out item))
                        return item;
                    else
                    {
                        item = new TValue();
                        Add(key, item);
                        return item;
                    }
                }
                set
                {
                    Add(key, value);
                }
            }
    
            public int Count
            {
                get
                {
                    return Dictionary.Count;
                }
            }
    
            public bool IsReadOnly
            {
                get
                {
                    return Dictionary.IsReadOnly;
                }
            }
    
            public ICollection<TKey> Keys
            {
                get
                {
                    return Dictionary.Keys;
                }
            }
    
            public ICollection<TValue> Values
            {
                get
                {
                    return Dictionary.Values;
                }
            }
    
            public void Add(KeyValuePair<TKey, TValue> item)
            {
                Add(item.Key, item.Value);
            }
    
            public void Add(TKey key, TValue value)
            {
                TValue item;
                if (Dictionary.TryGetValue(key, out item))
                {                
                    Type t = typeof(TValue);
                    var props = t.GetProperties();
                    foreach (var p in props)
                        p.SetValue(item, p.GetValue(value));
                }
                else
                    Dictionary.Add(key, value);
            }
    
            public void Clear()
            {
                Dictionary.Clear();
            }
    
            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                return Dictionary.Contains(item);
            }
    
            public bool ContainsKey(TKey key)
            {
                return Dictionary.ContainsKey(key);
            }
    
            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                Dictionary.CopyTo(array, arrayIndex);
            }
    
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                return Dictionary.GetEnumerator();
            }
    
            public bool Remove(KeyValuePair<TKey, TValue> item)
            {
                return Dictionary.Remove(item);
            }
    
            public bool Remove(TKey key)
            {
                return Dictionary.Remove(key);
            }
    
            public bool TryGetValue(TKey key, out TValue value)
            {
                return Dictionary.TryGetValue(key, out value);
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)Dictionary).GetEnumerator();
            }
        }
