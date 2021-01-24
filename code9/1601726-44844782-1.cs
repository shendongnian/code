    public class FooClass
    {
        public ObservableCollection<string> ItemsCollection { get; } = new ObservableCollection<string>();
        internal static FooClass Instance => _Instance ?? (_Instance = new FooClass());
        private static FooClass _Instance;
        private FooClass() { }
        private void _UpdateTheCollectionFromAnotherThread()
        {
            List<string> items = new List<string>();
            if (System.Windows.Application.Current.Dispatcher.CheckAccess())
                ClearCollection(items);
            else
                System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => ClearCollection(items)));
        }
        private void ClearCollection(List<string> items)
        {
            ItemsCollection.Clear();
            foreach (string item in items)
            {
                ItemsCollection.Add(item);
            }
        }
    }
