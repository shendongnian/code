    public class SynchronizedObservableCollection<T> : ObservableCollection<T>
    {
        private readonly object _lockObject = new object();
    
        public SynchronizedObservableCollection()
        {
            Init();
        }
    
        public SynchronizedObservableCollection(List<T> list) : base(list)
        {
            Init();
        }
    
        public SynchronizedObservableCollection(IEnumerable<T> collection) : base(collection)
        {
            Init();
        }
    
        private void Init()
        {
            BindingOperations.EnableCollectionSynchronization(this, _lockObject);
        }
    }
