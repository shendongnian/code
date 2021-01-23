    public class ObservableTestCollection<T> : ObservableCollection<T> {
        public T Parent;   
        //Copy constructor calls the instance constructor
        public ObservableTestCollection(T parent) : this(parent, Enumerable.Empty<T>()) {
            
        }
        //Instance constructor
        public ObservableTestCollection(T parent, IEnumerable<T> source) : base(source) {
            Parent = parent;
        }
    }
