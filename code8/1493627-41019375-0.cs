    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, e);
        }
    }
    private int _difference;
    public int Difference
    {
        get
        {
            return _difference;
        }
        set
        {
            _difference = value;
            OnPropertyChanged(new PropertyChangedEventArgs("Difference"));
        }
    }
