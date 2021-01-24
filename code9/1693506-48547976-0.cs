    public interface ISelectable
    {
        bool IsSelected { get; set; }
    }
    public class ItemEventArgs<T> : EventArgs
    {
        public T Item { get; }
        public ItemEventArgs(T item) => this.Item = item;
    }
    public class SelectionTracker<T> where T : ISelectable
    {
        private readonly ObservableCollection<T> _items;
        private readonly ObservableCollection<T> _selectedItems;
        private readonly ReadOnlyObservableCollection<T> _selectedItemsView;
        private readonly HashSet<T> _trackedItems;
        private readonly HashSet<T> _fastSelectedItems;
        public SelectionTracker(ObservableCollection<T> items)
        {
            _items = items;
            _selectedItems = new ObservableCollection<T>();
            _selectedItemsView = new ReadOnlyObservableCollection<T>(_selectedItems);
            _trackedItems = new HashSet<T>();
            _fastSelectedItems = new HashSet<T>();
            _items.CollectionChanged += OnCollectionChanged;
        }
        public event EventHandler<ItemEventArgs<T>> ItemSelected; 
        public event EventHandler<ItemEventArgs<T>> ItemUnselected; 
        public ReadOnlyObservableCollection<T> SelectedItems => _selectedItemsView;
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems == null)
                        goto default;
                    AddItems(e.NewItems.OfType<T>());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems == null)
                        goto default;
                    RemoveItems(e.OldItems.OfType<T>());
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldItems == null || e.NewItems == null)
                        goto default;
                    RemoveItems(e.OldItems.OfType<T>());
                    AddItems(e.NewItems.OfType<T>());
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                default:
                    RemoveItems(_trackedItems);
                    AddItems(_items);
                    break;
            }
        }
        private void AddItems(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var observableItem = item as INotifyPropertyChanged;
                if (observableItem != null)
                    observableItem.PropertyChanged += OnItemPropertyChanged;
                _trackedItems.Add(item);
                UpdateItem(item);
            }
        }
        private void RemoveItems(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var observableItem = item as INotifyPropertyChanged;
                if (observableItem != null)
                    observableItem.PropertyChanged -= OnItemPropertyChanged;
                _trackedItems.Remove(item);
                UpdateItem(item);
            }
        }
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is T item)
                UpdateItem(item);
        }
        private void UpdateItem(T item)
        {
            if (item?.IsSelected == true && _trackedItems.Contains(item))
            {
                if (_fastSelectedItems.Add(item))
                {
                    _selectedItems.Add(item);
                    this.ItemSelected?.Invoke(this, new ItemEventArgs<T>(item));
                }
            }
            else
            {
                if (_fastSelectedItems.Remove(item))
                {
                    _selectedItems.Remove(item);
                    this.ItemUnselected?.Invoke(this, new ItemEventArgs<T>(item));
                }
            }
        }
    }
