    private ObservableCollection<MyClass> _value; 
    public ObservableCollection<MyClass> Value 
    { 
        get
        {
            return _value;
        } 
        set
        {
            // I hope this line of code will convince you to give more clear variable name
            if(value != _value)
            {
                _value = value;
                NotifyPropertyChanged(nameof(Value));
            } 
        }
    }
