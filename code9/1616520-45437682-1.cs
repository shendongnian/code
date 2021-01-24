    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Collections.ObjectModel;
    
    namespace TurboLabz.Game
    {
        public class GenericComparer<TKey> : IComparer<TKey>
        {
            public static GenericComparer<TKey> CreateComparer(Func<TKey, TKey, int> comparer)
            {
                return new GenericComparer<TKey>(comparer);
            }
    
            internal GenericComparer(Func<TKey, TKey, int> comparer)
            {
                Comparer = comparer;
            }
    
            private Func<TKey, TKey, int> Comparer { get; set; }
    
            public int Compare(TKey x, TKey y)
            {
                return Comparer(x, y);
            }
        }
    
        public class OrderedDictionaryKC<TKey, TValue> : KeyedCollection<TKey,KeyValuePair<TKey, TValue>>
        {
            public OrderedDictionaryKC()
            { }
    
            public OrderedDictionaryKC(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            {            
                if (collection != null)
                {
                    foreach (KeyValuePair<TKey, TValue> item in collection)
                    {
                        base.Add(item);
                    }
                }
            }
    
            public OrderedDictionaryKC(IDictionary<TKey, TValue> dictionary) : this((IEnumerable<KeyValuePair<TKey, TValue>>)dictionary)
            { }
    
            public ICollection<TKey> Keys
            {
                get
                {
                    return base.Dictionary.Keys;
                }
            }
    
            public ICollection<KeyValuePair<TKey, TValue>> Values
            {
                get
                {
                    return base.Dictionary.Values;
                }
            }
    
            public void Add(TKey key, TValue value)
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }
    
                base.Add(new KeyValuePair<TKey, TValue>(key, value));
            }
    
            public bool ContainsKey(TKey key)
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }
    
                return base.Dictionary.ContainsKey(key);
            }
    
            public bool TryGetValue(TKey key, out TValue value)
            {
                KeyValuePair<TKey, TValue> outValue;
                var result=  base.Dictionary.TryGetValue(key, out outValue);
                value = outValue.Value;
    
                return result;
            }
    
            protected override TKey GetKeyForItem(KeyValuePair<TKey, TValue> item)
            {
                return item.Key;
            }
        }
    }
