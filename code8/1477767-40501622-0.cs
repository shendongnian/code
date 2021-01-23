    public class Track<T> {
    
        readonly List<Key<T>> _keys = new List<Key<T>>();
    
        public void AddKey(float time, T value) {
            var key = new Key<T> {
                Time = time,
                Value = value
            };
            _keys.Add(key); // <== Error: cannot convert Key<T> expression to type Key<T>
        }
    }
    
    public struct Key<T> {
        public float Time;
        public T Value;
    }
