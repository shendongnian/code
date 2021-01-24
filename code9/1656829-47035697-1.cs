    private List<int> _cmbList;
    public List<int> CmbList//this is the collection that we will use to hold values
    {
        get { return _cmbList; }
        set { _cmbList = value; OnPropertyChanged("CmbList"); }
    }
    //with additional property
    private int _ActRma;
    public int ActRma
    {
        get { return _ActRma; }
        set { _ActRma = value; OnPropertyChanged(nameof(ActRma)); }// In here you can handle the changed value of your ComboBox. No need for event handler in this case as setter is called everytime you change selected item in UI.
    }
  
