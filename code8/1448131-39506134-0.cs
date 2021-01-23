    private BindingList<string> _mybindinglist;
    public BindingList<string> myBindingList
    {
        get { return _mybindinglist; }
        set
        {
              _mybindinglist= value;
              OnPropertyChanged("myBindingList");          // or RaisePropertyChanged or whatever you used
        }
    }
