    public class MyDictionary {
        private readonly Dictionary<object, object> _innerDictionary = new Dictionary<object, object>();
        public void Add<T>(List<T> key, HashSet<T> value) where T : IInterface {
          _innerDictionary.Add(key, value);
        }
        public HashSet<T> Get<T>(List<T> key) where T : IInterface {
          return (HashSet<T>)_innerDictionary[key];
        }
        public void Set<T>(List<T> key, HashSet<T> value) where T : IInterface {
          _innerDictionary[key] = value;
        }
        // etc.
    }
