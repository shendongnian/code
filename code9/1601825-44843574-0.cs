    struct ObservableColor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public Color Value { get; private set; }
    
        public ObservableColor(Color color)
        {
            Value = color;
            PropertyChanged = null; // initiailze
        }
