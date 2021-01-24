    class MyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MyObject> _myList;
        public ObservableCollection<MyObject> MyList
        {
            get { return _myList; }
            set
            {
                _myList = value; 
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
