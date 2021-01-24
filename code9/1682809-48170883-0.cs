      public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Items = new ObservableCollection<string> {"item1", "item2"};
            _fontSize = 12d;
        }
        public ObservableCollection<string> Items { get; set; }
        private double _fontSize;
        public double FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged(nameof(FontSize));
            }
        }
        #region INotifyPropertyChangedImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
