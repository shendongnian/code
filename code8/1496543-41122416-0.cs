    private Type _yourProperty;
    public Type YourProperty
    {
       get { return _yourProperty; }
       set
       {
          _yourProperty = value;
          OnPropertyChanged();
       }
    }
    public event PropertyChangedEventHandler PropertyChanged;    
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
       PropertyChangedEventHandler handler = PropertyChanged;
       handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
