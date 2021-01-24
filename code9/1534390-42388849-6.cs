    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Models = new ObservableCollection<Model>() { new Model() {Name = "aaaa", Desc = "desc1" }, new Model() { Name = "bbbbb", Desc="desc2"  } };
            Items = new ObservableCollection<PropertyInfo>(typeof(Model).GetProperties());
            SelectedItem = Items[0];
        }
        ObservableCollection<PropertyInfo> _items;
        public ObservableCollection<PropertyInfo> Items { get { return _items; } set { _items = value; RaisePropertyChanged("Items"); } }
        PropertyInfo _selectedItem;
        public PropertyInfo SelectedItem { get { return _selectedItem; } set {
                _selectedItem = value; RaisePropertyChanged("SelectedItem"); 
            } }
        ObservableCollection<Model> _models;
        public ObservableCollection<Model> Models { get { return _models; }set { _models = value; RaisePropertyChanged("Models"); } }
      public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
