    private string _myText;
    
    public string MyText 
    {
      get 
      {
         return _myText;
      }
      set
      {
        _myText = value;
        OnPropertyChanged();
      }
    }
