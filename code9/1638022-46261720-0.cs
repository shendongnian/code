    public class SyncSortedDictionary<T1,T2> : INotifyCollectionChanged, IDictionary<T1,T2>
    {
        #region Fields
        private readonly SortedDictionary<T1,T2> _items;
        #endregion
        #region Events
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
        #region Notify
        private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index));
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index, int oldIndex)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index, oldIndex));
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action, object oldItem, object newItem, int index)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, newItem, oldItem, index));
        }
        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            var collectionChanged = CollectionChanged;
            if (collectionChanged == null)
                return;
            collectionChanged(this, e);
        }
        #endregion
        #region Public Methods
        public void Add(KeyValuePair<T1, T2> item)
        {
            int index = _items.Count;
            _items.Add(item.Key, item.Value);
            OnCollectionChanged(NotifyCollectionChangedAction.Add, item, index);
        }
        #endregion
    }
