    public class ObserverClass
    {
        public ObserverClass()
        {
            ObservableIntegers.CollectionChanged += ObservableIntegersOnCollectionChanged;
            //Add item to collection while preventing self-handling the callback
            ObservableIntegers.Add(1, ObservableIntegersOnCollectionChanged);
        }
        private void ObservableIntegersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            // Handle collection change
        }
        public ObservableCollection<int> ObservableIntegers { get; set; }
    }
