    public class SynchronizingCollection<T> : ObservableCollection<T>
    {
        // the second, synchroniozed collection
        SynchronizingCollection<T> _synchronizedCollection;
        // field used to determine if the synchronization is already in progress
        bool _isSynchronizing = false;
        // Methods AddRange, RemoveItems, ReplaceAll, ClearAll
        // prevent CollectionChanged event from being rised unnecessarily
        // and allow for adding/clearing/replacing items in bulk
        public void AddRange(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            foreach (T item in range)
            {
                this.Items.Add(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, (IList)range.ToList()));
        }
        public void ReplaceAll(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            this.Items.Clear();
            foreach (T item in range)
            {
                this.Items.Add(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public void RemoveItems(IEnumerable<T> range)
        {
            if (range == null)
                throw new ArgumentNullException("range");
            foreach (T item in range)
            {
                this.Items.Remove(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, (IList)range.ToList()));
        }
        public void ClearAll()
        {
            IList old = this.Items.ToList();
            base.Items.Clear();
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old));
        }
        
        // assigning the second collection as synchronized
        public void SetSynchronizedCollection(SynchronizingCollection<T> synchronized)
        {
            this._synchronizedCollection = synchronized;
            this._synchronizedCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(_synchronized_CollectionChanged);
            this.CollectionChanged += new NotifyCollectionChangedEventHandler(this_CollectionChanged);
        }
        void this_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_isSynchronizing || _synchronizedCollection==null) return;
            _isSynchronizing = true;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _synchronizedCollection.AddRange(e.NewItems.OfType<T>());
                    break;
                case NotifyCollectionChangedAction.Move:
                    // implement...
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _synchronizedCollection.RemoveItems(e.OldItems.OfType<T>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    // implement...
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _synchronizedCollection.ReplaceAll(this.Items);
                    break;
            }
            _isSynchronizing = false;
        }
        void _synchronized_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_isSynchronizing) return;
            _isSynchronizing = true;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    this.AddRange(e.NewItems.OfType<T>());
                    break;
                case NotifyCollectionChangedAction.Move:
                    // implement...
                    break;
                case NotifyCollectionChangedAction.Remove:
                    this.RemoveItems(e.OldItems.OfType<T>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    // implement...
                    break;
                case NotifyCollectionChangedAction.Reset:
                    this.ReplaceAll(_synchronizedCollection.Items);
                    break;
            }
            _isSynchronizing = false;
        }
    }
