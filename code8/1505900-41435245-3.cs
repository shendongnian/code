    public class ObservableTestCollection<T> : ObservableCollection<T> {
        public T Parent;   
        //This constructor calls the instance constructor
        public ObservableTestCollection(T parent) : this(parent, Enumerable.Empty<T>()) {
            
        }
        //Instance constructor is calling the base constructor
        public ObservableTestCollection(T parent, IEnumerable<T> source) : base(source) {
            Parent = parent;
        }
    }
