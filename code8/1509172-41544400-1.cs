    public event PropertyChangedEventHandler PropertyChanged;
    private string uname;
    public string Uname
    {
        get
        {
            return uname;
        }
    
        set
        {
            uname = value;
            OnPropertyChanged();
        }
    }
      
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler eventHandler = this.PropertyChanged;
        if (eventHandler != null)
        {
            eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
