    public class DateTimeJsonSerializer : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                return null;
            return new JavaScriptSerializer().ConvertToType(dictionary, type);
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (!(obj is DateTime)) return null;
            return new CustomString(((DateTime) obj).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type> { typeof(DateTime), typeof(DateTime?) }); }
        }
    }
    public class CustomString : Uri, IDictionary<string, object>
    {
        public CustomString(string str) : base(str, UriKind.Relative)
        {}
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public bool Remove(KeyValuePair<string, object> item)
        {
            throw new NotImplementedException();
        }
        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }
        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }
        public void Add(string key, object value)
        {
            throw new NotImplementedException();
        }
        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(string key, out object value)
        {
            throw new NotImplementedException();
        }
        public object this[string key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public ICollection<string> Keys { get; private set; }
        public ICollection<object> Values { get; private set; }
    }
