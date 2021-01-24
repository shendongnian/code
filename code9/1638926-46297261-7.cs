     private ObservableCollection<ItemsClass> itemsCollection;
        internal ObservableCollection<ItemsClass> ItemsCollection
        {
            get { return itemsCollection; }
            set { itemsCollection = value; RaisePropertyChanged(nameof(ItemsCollection)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private void ItemSelected(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is ItemsClass selectedItem)
                selectedItem.IsFavorite = !selectedItem.IsFavorite;
        }
