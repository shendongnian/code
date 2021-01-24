    public class MyItemsClassThing : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
