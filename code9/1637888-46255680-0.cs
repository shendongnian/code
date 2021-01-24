    public string Test { 
       get { return _test; }
       set {
          _test = value;
          PropertyChanged?.Invoke(...);
       }
    }
