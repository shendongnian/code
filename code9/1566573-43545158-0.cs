    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private VirtualCollection _myVirtualCollectionList;
        public VirtualCollection MyVirtualCollectionList
        {
            get { return _myVirtualCollectionList; }
            set
            {
                _myVirtualCollectionList = value;
                OnPropertyChanged();
            }
        }
        private VirtualCollectionItem _selectedItem;
        public VirtualCollectionItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
    }
                
