    public class AirplaneTypeCollection : IEnumerable<Type>
    {
        List<Type> _types = new List<Type>();
        public AirplaneTypeCollection()
        {
        }
        public void AddType<T>() where T: Airplane
        {
            _types.Add(typeof(T));
        }
        public IEnumerator GetEnumerator()
        {
            return _types.GetEnumerator();
        }
        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            return _types.GetEnumerator();
        }
    }
