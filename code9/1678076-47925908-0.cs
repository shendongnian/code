    private string _myProperty;
    public string MyProperty
    { 
       get {  return _myProperty; }
       set { this.Set<string>(ref _myProperty, value); }
    }
