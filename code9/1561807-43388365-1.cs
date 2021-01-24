    public class ObservableKeyedCollection<TKey, TItem> : KeyedCollection<TKey, TItem>, INotifyCollectionChanged
    {
        private const string CountString = "Count";
        private readonly Func<TItem, TKey> _getKeyForItemDelegate;
        // Constructor now requires a delegate to get the key from the item
        public ObservableKeyedCollection(Func<TItem, TKey> getKeyForItemDelegate) : base()
        {
            if (getKeyForItemDelegate == null)
                throw new ArgumentNullException("Delegate passed can't be null!");
            _getKeyForItemDelegate = getKeyForItemDelegate;
        }
        protected override TKey GetKeyForItem(TItem item)
        {
            return _getKeyForItemDelegate(item);
        }
        /// <summary>
        /// Method to add a new object to the collection, or to replace an existing one if there is 
        /// already an object with the same key in the collection.
        /// </summary>
        public void AddOrReplace(TItem newObject)
        {
            int i = GetItemIndex(newObject);
            if (i != -1)
                SetItem(i, newObject);
            else
                Add(newObject);
        }
        /// <summary>
        /// Method to replace an existing object in the collection, i.e., an object with the same key. 
        /// An exception is thrown if there is no existing object with the same key.
        /// </summary>
        public void Replace(TItem newObject)
        {
            int i = GetItemIndex(newObject);
            if (i != -1)
                SetItem(i, newObject);
            else
                throw new Exception("Object to be replaced not found in collection.");
        }
        /// <summary>
        /// Method to get the index into the List{} in the base collection for an item that may or may 
        /// not be in the collection. Returns -1 if not found.
        /// </summary>
        private int GetItemIndex(TItem itemToFind)
        {
            TKey keyToFind = GetKeyForItem(itemToFind);
            if (this.Contains(keyToFind))
                return this.IndexOf(this[keyToFind]);
            else return -1;
        }
        // Overrides a lot of methods that can cause collection change
        protected override void SetItem(int index, TItem item)
        {
            var oldItem = base[index];
            base.SetItem(index, item);
            OnCollectionChanged(NotifyCollectionChangedAction.Replace, item, oldItem);
        }
        protected override void InsertItem(int index, TItem item)
        {
            base.InsertItem(index, item);
            OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }
        protected override void ClearItems()
        {
            base.ClearItems();
            OnCollectionChanged();
        }
        protected override void RemoveItem(int index)
        {
            TItem item = this[index];
            base.RemoveItem(index);
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);
        }
        private bool _deferNotifyCollectionChanged = false;
        public void AddRange(IEnumerable<TItem> items)
        {
            _deferNotifyCollectionChanged = true;
            foreach (var item in items)
                Add(item);
            _deferNotifyCollectionChanged = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (_deferNotifyCollectionChanged)
                return;
            if (CollectionChanged != null)
                CollectionChanged(this, e);
        }
        #region INotifyCollectionChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private void OnPropertyChanged()
        {
            OnPropertyChanged(CountString);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnCollectionChanged()
        {
            if (_deferNotifyCollectionChanged)
                return;
            OnPropertyChanged();
            if (CollectionChanged != null) CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action, TItem changedItem)
        {
            if (_deferNotifyCollectionChanged)
                return;
            OnPropertyChanged();
            if (CollectionChanged != null) CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, changedItem));
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action, TItem newItem, TItem oldItem)
        {
            if (_deferNotifyCollectionChanged)
                return;
            OnPropertyChanged();
            if (CollectionChanged != null) CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
        }
        private void OnCollectionChanged(NotifyCollectionChangedAction action, IList newItems)
        {
            if (_deferNotifyCollectionChanged)
                return;
            OnPropertyChanged();
            if (CollectionChanged != null) CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItems));
        }
        #endregion
    }
