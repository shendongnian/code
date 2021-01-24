    // Proxy class for any enumerable with the requisite `Add` methods.
    public class EnumerableProxy<T> : IEnumerable<T>
    {
        readonly Action<T> add;
        readonly Func<IEnumerable<T>> getEnumerable;
        // XmlSerializer required default constructor (which can be private).
        EnumerableProxy()
        {
            throw new NotImplementedException("The parameterless constructor should never be called directly");
        }
        public EnumerableProxy(Func<IEnumerable<T>> getEnumerable, Action<T> add)
        {
            if (getEnumerable == null || add == null)
                throw new ArgumentNullException();
            this.getEnumerable = getEnumerable;
            this.add = add;
        }
        public void Add(T obj)
        {
            // Required Add() method as documented here:
            // https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer%28v=vs.100%29.aspx
            add(obj);
        }
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return (getEnumerable() ?? Enumerable.Empty<T>()).GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
