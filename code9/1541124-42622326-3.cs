    public class Item : INotifyPropertyChanged
    { 
        string _displayText;
        public string DisplayText { get { return _displayText; } set { _displayText = value; RaisePropertyChanged("DisplayText"); } }
 
        ObservableCollection<Item> _items;
        public ObservableCollection<Model> Items { get { return _items; } set { _items = value; RaisePropertyChanged("Items"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    } 
