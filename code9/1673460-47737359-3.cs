    public class Detail : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private List<int> _myList;
        public List<int> MyList
        {
           get => _myList;
           set 
           {
              _myList = value;
              NotifyPropertyChanged();
           } 
        }    
    }
