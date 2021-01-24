    public class MainViewModel
    {
        // Source Id collection
        public ObservableCollection<Id> Ids { get; }
        // Empty Id collection
        public ObservableCollection<Id> Empty { get; } = new ObservableCollection<Id>();
        // Composite (combination of Source + Empty collection)
        // View should bind to this instead of Ids
        public CompositeCollection ViewIds { get; }
        // Constructor
        public MainViewModel(ObservableCollection<Id> ids)
        {
            ViewIds = new CompositeCollection();
            ViewIds.Add(new CollectionContainer {Collection = Empty });
            ViewIds.Add(new CollectionContainer {Collection = Ids = ids });
            // Whenever something changes in Ids, Update the collections
            CollectionChangedEventManager.AddHandler(Ids, delegate { UpdateEmptyCollection(); });
            UpdateEmptyCollection(); // First time
        }
        private void UpdateEmptyCollection()
        {
            // If the source collection is empty, push an "Empty" id into the Empty colleciton
            if (Ids.Count == 0)
                Empty.Add(new Id("Empty"));
            // Otherwise (has Ids), clear the Empty collection
            else
                Empty.Clear();
        }
    }
