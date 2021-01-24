    public class ListViewItemsData : INotifyPropertyChanged
    {
        private string _itemsName;
        public string ItemsName
        {
            get { return _itemsName; }
            set { _itemsName = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
