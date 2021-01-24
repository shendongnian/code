    public class Container<T> : IEnumerable<T>
    {
        // forward the non-generic version to the generic version
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        // implement GetEnumerator from the generic interface
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
