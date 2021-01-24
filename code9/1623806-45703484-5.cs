    private ComboItem _selected = null;
    public ComboItem SelectedComboItem
    { 
      get { return _selected; }
      set
      {
        _selected = value;
        OnPropertyChanged("SelectedComboItem");
      }
    }
