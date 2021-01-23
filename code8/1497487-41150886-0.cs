    private string _SelectedLand;
    public string SelectedLand
    {
       get
       {
          return _SelectedLand;
       }
       set
       {
          _SelectedLand = value;
          RaisePropertyChanged("SelectedLand");
          RaisePropertyChanged("Gewesten");
       }
    }
