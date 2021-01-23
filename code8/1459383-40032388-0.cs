    public class ChildNotifier<T> : INotifyPropertyChanged where T : INotifyPropertyChanged
    {
        private ObservableCollection<T> _list;
        public ObservableCollection<T> List
        {
            get { return _list; }
            set
            {
                if (Equals(value, _list)) return;
                _list = value;
                foreach (T item in _list)
                    item.PropertyChanged += ChildOnPropertyChanged;
                OnPropertyChanged();
            }
        }
        protected ChildNotifier(IEnumerable<T> list)
        {
            _list = new ObservableCollection<T>(list);
            _list.CollectionChanged += ItemsOnCollectionChanged;
            foreach (T item in _list)
                item.PropertyChanged += ChildOnPropertyChanged;
        }
        protected abstract void ChildOnPropertyChanged(object sender, propertyChangedEventArgs e);
        private void ItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (T item in e.NewItems)
                    item.PropertyChanged += ChildOnPropertyChanged;
            if (e.OldItems != null)
                foreach (T item in e.OldItems)
                    item.PropertyChanged -= ChildOnPropertyChanged;
            OnPropertyChanged();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
