    public class ObservableTestCollection<T> : ObservableCollection<T> {
        public T Parent;   
        public ObservableTestCollection(T parent): this(parent, Enumerable.Empty<T>()) {
            
        }
        public ObservableTestCollection(T parent, IEnumerable<T> source): base(source) {
            Parent = parent;
        }
    }
