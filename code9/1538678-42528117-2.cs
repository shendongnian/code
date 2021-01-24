    class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Items { get; set; } = new ObservableCollection<Person>();
        private Person _selectedItem;
        public Person SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if(_selectedItem != null && _selectedItem.Equals(value)) { return; }
                _selectedItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }
        // INotifyPropertyChanged emplementation
        public event PropertyChangedEventHandler PropertyChanged;
    }
