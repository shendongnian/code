    public class FooClass
    {
        private readonly object _lock = new object();
        public ObservableCollection<string> ItemsCollection { get; } = new ObservableCollection<string>();
        internal static FooClass Instance => _Instance ?? (_Instance = new FooClass());
        private static FooClass _Instance;
        private FooClass()
        {
            BindingOperations.EnableCollectionSynchronization(ItemsCollection, _lock);
        }
        private void _UpdateTheCollectionFromAnotherThread()
        {
            List<string> items = new List<string>();
            ItemsCollection.Clear();
            foreach (string item in items)
            {
                ItemsCollection.Add(item);
            }
        }
    }
