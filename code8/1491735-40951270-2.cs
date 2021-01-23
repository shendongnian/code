    static class MultiDictionaryExtension
    {
        #region Extension
        public static IEnumerable<IDictionary<TK, TV>> AsSeparatedDictionaries<TK, TV>(this IDictionary<TK, List<TV>> multiDict)
        {
            int numDictionaries = multiDict.First().Value.Count;
            for (int i = 0; i < numDictionaries; i++)
                yield return new SingleDictionaryWrap<TK, TV>(multiDict, i);
        }
        #endregion
        #region Helper classes
        public class SingleDictionaryWrap<TK, TV> : IDictionary<TK, TV>
        {
            private class ValueCollection : ICollection<TV>
            {
                private readonly SingleDictionaryWrap<TK, TV> dict;
                public ValueCollection(SingleDictionaryWrap<TK, TV> dict)
                {
                    this.dict = dict;
                }
                public int Count { get { return this.dict.Count; } }
                public bool IsReadOnly { get { return false; } }
                public void Add(TV item) { throw new NotSupportedException("This dictionary is readonly"); }
                public void Clear() { throw new NotSupportedException("This dictionary is readonly"); }
                public bool Contains(TV item) { return this.dict.Select(x => x.Value).Contains(item); }
                public void CopyTo(TV[] array, int arrayIndex) { foreach (var item in this) array[arrayIndex++] = item; }
                public IEnumerator<TV> GetEnumerator() { return this.dict.Select(x => x.Value).GetEnumerator(); }
                public bool Remove(TV item) { throw new NotSupportedException("This dictionary is readonly"); }
                IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
            }
            private readonly IDictionary<TK, List<TV>> multiDict;
            public int Index { get; private set; }
            public SingleDictionaryWrap(IDictionary<TK, List<TV>> multiDict, int index)
            {
                this.Index = index;
                this.multiDict = multiDict;
            }
            public ICollection<TK> Keys { get { return this.multiDict.Keys; } }
            public ICollection<TV> Values { get { return new ValueCollection(this); } }
            public int Count { get { return this.multiDict.Count; } }
            public bool IsReadOnly { get { return true; } }
            public TV this[TK key]
            {
                get { return this.multiDict[key][this.Index]; }
                set { throw new NotSupportedException("This dictionary is readonly"); }
            }
            public bool ContainsKey(TK key) { return this.multiDict.ContainsKey(key); }
            public void Add(TK key, TV value) { throw new NotSupportedException("This dictionary is readonly"); }
            public bool Remove(TK key) { throw new NotSupportedException("This dictionary is readonly"); }
            public bool TryGetValue(TK key, out TV value)
            {
                value = default(TV);
                List<TV> values;
                if (this.multiDict.TryGetValue(key, out values))
                {
                    value = values[this.Index];
                    return true;
                }
                return false;
            }
            public void Add(KeyValuePair<TK, TV> item) { throw new NotSupportedException("This dictionary is readonly"); }
            public void Clear() { throw new NotSupportedException("This dictionary is readonly"); }
            public bool Contains(KeyValuePair<TK, TV> item)
            {
                TV value;
                if (this.TryGetValue(item.Key, out value))
                {
                    return Object.Equals(value, item.Value);
                }
                return false;
            }
            public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex) { foreach (var kvp in this) array[arrayIndex++] = kvp; }
            public bool Remove(KeyValuePair<TK, TV> item) { throw new NotSupportedException("This dictionary is readonly"); }
            public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator() { return this.multiDict.Select(kvp => new KeyValuePair<TK, TV>(kvp.Key, kvp.Value[this.Index])).GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
        }
        #endregion
    }
