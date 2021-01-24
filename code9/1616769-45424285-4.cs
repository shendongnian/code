    public class Global : INotifyPropertyChanged
    {
    	private Global() { }
        public Global Instance { get; } = new Global();
    
        private bool _isReadOnly;
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                if (_isReadOnly != value)
                {
                    _isReadOnly = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(IsReadOnly)));
                }
            }
        }
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    }
