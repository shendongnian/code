    public ICollection Numbers {get;set {RaisePropertyChanged("Numbers")}
    public ICollection Colors {get;set {RaisePropertyChanged("Colors")}
    
    public int SelectedNumber 
    {
    get{ return _selectedNumber; }
    set
    {
    _selectedNumber = value;
    RaisePropertyChanged("SelectedNumber");
    //
    Here Modify the Colors collections by calling other method which can filter or modify Colors using LINQ i.e.
    ModifyColorsCollection(value);
        //
    }
