    public class Item : INotifyPropertyChanged
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
