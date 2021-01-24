    public class VM1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IEnumerable _collection;
        private string _selectedName;
        public IEnumerable Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Collection)));
            }
        }
        public string SelectedName 
        {
            get { return _selectedName; }
            set
            {
                _selectedName = value;
                // Set Collection property based on the _selectedName
                if (_selectedName == "A")
                    Collection = new[] { 1, 2, 3 }; // Collection 1
                else if (_selectedName == "B")
                    Collection = new[] { 4, 5, 6 }; // Collection 2
            }
        }
    }
