    public class ParentViewModel : INotifyPropertyChanged
    {
        private readonly Model _model;
    
        public ParentViewModel(Model model)
        {
            _model = model;
            Items = new ObservableCollection<ItemViewModel>(_model.Items.Select(i => new ItemViewModel(i)));
            foreach(var item in Items)
            {
                item.PropertyChanged += ChildOnPropertyChanged;
            }
            Items.CollectionChanged += ItemsOnCollectionChanged;
        }
    
        private void ItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Item item in e.NewItems)
                    item.PropertyChanged += ChildOnPropertyChanged;
    
            if (e.OldItems != null)
                foreach (Item item in e.OldItems)
                    item.PropertyChanged -= ChildOnPropertyChanged;
            OnPropertyChanged(nameof(ItemsTotal));
        }
    
        private void ChildOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (e.PropertyName == "Value")
                OnPropertyChanged(nameof(ItemsTotal));
        }
    
        public ObservableCollection<ItemViewModel> Items;
        public int ItemsTotal => Items.Sum(item => item.Value);
    
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
