    public class ViewModel:INotifyPropertyChanged
    {
        public ViewModel()
        {
            _value = 0;
            _minimum = 0;
            _maximum = 180;
            _step = 10;
        }
    
        private int _step;
        private int _minimum;
        private int _maximum;
    
        private ICommand _increaseCommand;
        public ICommand IncreaseCommand
        {
            get
            {
                if (_increaseCommand == null)
                {
                    _increaseCommand = new RelayCommand(
                    p => _value + _step <= _maximum,
                    Increase);
                }
                return _increaseCommand;
            }
        }
    
        private ICommand _decreaseCommand;
        public ICommand DecreaseCommand
        {
            get
            {
                if (_decreaseCommand == null)
                {
                    _decreaseCommand = new RelayCommand(
                    p => _value - _step >= _minimum,
                    Decrease);
                }
                return _decreaseCommand;
            }
        }
    
    
        private void Increase(object param)
        {
            Value = Value + _step;
        }
    
        private void Decrease(object param)
        {
            Value = Value - _step;
        }
    
        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; InvokePropertyChanged(new PropertyChangedEventArgs("Value")); }
        }
    
        public int Minimum
        {
            get { return _minimum; }
        }
    
        public int Maximum
        {
            get { return _maximum; }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
