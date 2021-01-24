    public class MainPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public ObservableCollection<Item> Items { get; set; }
    
        public MainPageModel()
        {
            Items = new ObservableCollection<Item>
            {
                new Item("Item 1","First item"),
                new Item("Item 2","Second item"),
                new Item("Item 3","Third item"),
                new Item("Item 4","Fourth item"),
                new Item("Item 5","Fifth item")
            };
    
            SelectedItem = Items[2];
        }
    
        private Item _selectedItem;
        public Item SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
    }
