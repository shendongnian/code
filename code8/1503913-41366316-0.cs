    private string _aclBoxText;
    public string ACLBoxText {
        get { return _aclBoxText; }
        set {
            _aclBoxText = value;
            OnNotifyPropertyChanged("ACLBoxText");
        }
    }
    protected void OnPropertyChanged(string name)
    {
        var handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(name));
    }
    public event PropertyChangedEventHandler PropertyChanged;
