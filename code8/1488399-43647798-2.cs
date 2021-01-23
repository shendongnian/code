    public class ConnectionStringSettingsCollection : IDictionary<String, ConnectionStringSettings>
    {
        private readonly Dictionary<String, ConnectionStringSettings> m_ConnectionStrings;
        public ConnectionStringSettingsCollection()
        {
            m_ConnectionStrings = new Dictionary<String, ConnectionStringSettings>();
        }
        public ConnectionStringSettingsCollection(int capacity)
        {
            m_ConnectionStrings = new Dictionary<String, ConnectionStringSettings>(capacity);
        }
        #region IEnumerable methods
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)m_ConnectionStrings).GetEnumerator();
        }
        #endregion
        #region IEnumerable<> methods
        IEnumerator<KeyValuePair<String, ConnectionStringSettings>> IEnumerable<KeyValuePair<String, ConnectionStringSettings>>.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).GetEnumerator();
        }
        #endregion
        #region ICollection<> methods
        void ICollection<KeyValuePair<String, ConnectionStringSettings>>.Add(KeyValuePair<String, ConnectionStringSettings> item)
        {
            ((ICollection<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).Add(item);
        }
        void ICollection<KeyValuePair<String, ConnectionStringSettings>>.Clear()
        {
            ((ICollection<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).Clear();
        }
        Boolean ICollection<KeyValuePair<String, ConnectionStringSettings>>.Contains(KeyValuePair<String, ConnectionStringSettings> item)
        {
            return ((ICollection<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).Contains(item);
        }
        void ICollection<KeyValuePair<String, ConnectionStringSettings>>.CopyTo(KeyValuePair<String, ConnectionStringSettings>[] array, Int32 arrayIndex)
        {
            ((ICollection<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).CopyTo(array, arrayIndex);
        }
        Boolean ICollection<KeyValuePair<String, ConnectionStringSettings>>.Remove(KeyValuePair<String, ConnectionStringSettings> item)
        {
            return ((ICollection<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).Remove(item);
        }
        public Int32 Count => ((ICollection<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).Count;
        public Boolean IsReadOnly => ((ICollection<KeyValuePair<String, ConnectionStringSettings>>)m_ConnectionStrings).IsReadOnly;
        #endregion
        #region IDictionary<> methods
        public void Add(String key, ConnectionStringSettings value)
        {
            // NOTE only slight modification, we add back in the Name of connectionString here (since it is the key)
            value.Name = key;
            m_ConnectionStrings.Add(key, value);
        }
        public Boolean ContainsKey(String key)
        {
            return m_ConnectionStrings.ContainsKey(key);
        }
        public Boolean Remove(String key)
        {
            return m_ConnectionStrings.Remove(key);
        }
        public Boolean TryGetValue(String key, out ConnectionStringSettings value)
        {
            return m_ConnectionStrings.TryGetValue(key, out value);
        }
        public ConnectionStringSettings this[String key]
        {
            get => m_ConnectionStrings[key];
            set => m_ConnectionStrings[key] = value;
        }
        public ICollection<String> Keys => m_ConnectionStrings.Keys;
        public ICollection<ConnectionStringSettings> Values => m_ConnectionStrings.Values;
        #endregion
    }
