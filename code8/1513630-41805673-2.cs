    internal sealed class DynamicDeserialisationStore<T> : DynamicObject, IDictionary<string, object> where T : class
    {
        private readonly Action<string, T> storeValue;
        private readonly Func<string, bool> removeValue;
        private readonly Func<string, T> retrieveValue;
        private readonly Func<IEnumerable<string>> retrieveKeys;
        public DynamicDeserialisationStore(
            Action<string, T> storeValue,
            Func<string, bool> removeValue,
            Func<string, T> retrieveValue,
            Func<IEnumerable<string>> retrieveKeys)
        {
            this.storeValue = storeValue;
            this.removeValue = removeValue;
            this.retrieveValue = retrieveValue;
            this.retrieveKeys = retrieveKeys;
        }
        public int Count
        {
            get
            {
                return this.retrieveKeys().Count();
            }
        }
        private IReadOnlyDictionary<string, T> AsDict
        {
            get
            {
                return (from key in this.retrieveKeys()
                        let value = this.retrieveValue(key)
                        select new { key, value })
                        .ToDictionary(it => it.key, it => it.value);
            }
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length == 1 && indexes[0] is string && value is JObject)
            {
                return this.TryUpdateValue(indexes[0] as string, value);
            }
            return base.TrySetIndex(binder, indexes, value);
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1 && indexes[0] is string)
            {
                try
                {
                    result = this.retrieveValue(indexes[0] as string);
                    return true;
                }
                catch (KeyNotFoundException)
                {
                    // Pass through.
                }
            }
            return base.TryGetIndex(binder, indexes, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return this.TryUpdateValue(binder.Name, value);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            try
            {
                result = this.retrieveValue(binder.Name);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return base.TryGetMember(binder, out result);
            }
        }
        private bool TryUpdateValue(string name, object value)
        {
            JObject jObject = value as JObject;
            T tObject = value as T;
            if (jObject != null)
            {
                this.storeValue(name, jObject.ToObject<T>());
                return true;
            }
            else if (tObject != null)
            {
                this.storeValue(name, tObject);
                return true;
            }
            return false;
        }
        object IDictionary<string, object>.this[string key]
        {
            get
            {
                return this.retrieveValue(key);
            }
            set
            {
                this.TryUpdateValue(key, value);
            }
        }
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.AsDict.ToDictionary(it => it.Key, it => it.Value as object).GetEnumerator();
        }
        public void Add(string key, object value)
        {
            this.TryUpdateValue(key, value);
        }
        public bool Remove(string key)
        {
            return this.removeValue(key);
        }
        #region Unused methods
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        ICollection<string> IDictionary<string, object>.Keys
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        ICollection<object> IDictionary<string, object>.Values
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }
        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            throw new NotImplementedException();
        }
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }
        bool IDictionary<string, object>.ContainsKey(string key)
        {
            throw new NotImplementedException();
        }
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }
        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
