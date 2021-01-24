    class HierarchicalTableItem
    {
        public string Text { get; }
        public IReadOnlyList<HierarchicalTableItem> Items { get; }
        public HierarchicalTableItem(string text, HierarchicalTableItem child = null)
        {
            Text = text;
            Items = child != null ? new[] { child } : null;
        }
    }
    class ViewModel
    {
        public ICommand AddCommand { get; }
        public ICommand InsertCommand { get; }
        public ICommand RemoveCommand { get; }
        public int Index { get; set; }
        public ObservableCollection<TableItem> TableItems { get; } = new ObservableCollection<TableItem>();
        public ViewModel()
        {
            AddCommand = new DelegateCommand(() => TableItems.Add(_CreateTableItem()));
            InsertCommand = new DelegateCommand(() => TableItems.Insert(Index, _CreateTableItem()));
            RemoveCommand = new DelegateCommand(() => TableItems.RemoveAt(Index));
        }
        private int _itemNumber;
        private TableItem _CreateTableItem()
        {
            _itemNumber = (_itemNumber < TableItems.Count ? TableItems.Count : _itemNumber) + 1;
            return new TableItem(
                $"Item #{_itemNumber}, property #1",
                $"Item #{_itemNumber}, property #2",
                $"Item #{_itemNumber}, property #3");
        }
    }
    class ConvertingObservableCollection<T> : ObservableCollection<object>
    {
        private readonly IValueConverter _converter;
        private readonly ObservableCollection<T> _collection;
        public ConvertingObservableCollection(IValueConverter converter, ObservableCollection<T> collection)
        {
            _converter = converter;
            _collection = collection;
            _ResetItems();
            _collection.CollectionChanged += _OnCollectionChanged;
        }
        private void _OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _AddItems(e);
                    break;
                case NotifyCollectionChangedAction.Move:
                    _RemoveItems(e);
                    _AddItems(e);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _RemoveItems(e);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    _ReplaceItems(e);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _ResetItems();
                    break;
            }
        }
        private void _ReplaceItems(NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < e.NewItems.Count; i++)
            {
                this[i] = _Convert(e.NewItems[i]);
            }
        }
        private void _AddItems(NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < e.NewItems.Count; i++)
            {
                Insert(i + e.NewStartingIndex, _Convert(e.NewItems[i]));
            }
        }
        private void _RemoveItems(NotifyCollectionChangedEventArgs e)
        {
            for (int i = e.OldItems.Count - 1; i >= 0; i--)
            {
                RemoveAt(i + e.OldStartingIndex);
            }
        }
        private void _ResetItems()
        {
            Clear();
            foreach (T t in _collection)
            {
                Add(_Convert(t));
            }
        }
        private object _Convert(object value)
        {
            return _converter.Convert(value, typeof(T), null, null);
        }
    }
    class TableItemHierarchicalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TableItem tableItem = value as TableItem;
            if (tableItem == null)
            {
                return Binding.DoNothing;
            }
            return new HierarchicalTableItem(tableItem.Property1,
                        new HierarchicalTableItem(tableItem.Property2,
                            new HierarchicalTableItem(tableItem.Property3)));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class ConvertingCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IValueConverter converter = parameter as IValueConverter;
            if (converter == null || value == null ||
                value.GetType().GetGenericTypeDefinition() != typeof(ObservableCollection<>))
            {
                return Binding.DoNothing;
            }
            Type resultType = typeof(ConvertingObservableCollection<>).MakeGenericType(value.GetType().GenericTypeArguments);
            return Activator.CreateInstance(resultType, converter, value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
