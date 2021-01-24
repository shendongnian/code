    private MyEnum _selectedMyEnumValue;
    public MyEnum SelectedMyEnumValue
    {
        get { return _selectedMyEnumValue; }
        set
        {
            if (value != this._selectedMyEnumValue)
            {
                this._selectedMyEnumValue = value;
                OnPropertyChanged();
            }
        }
    }
    private IEnumerable<MyEnum> _allMyEnumValues;
    public IEnumerable<MyEnum> AllMyEnumValues
    {
        get
        {
            if (this._allMyEnumValues == null)
            {
                this._allMyEnumValues = Enum.GetValues(typeof(MyEnum)).Cast<MyEnum>();
            }
            return _allMyEnumValues;
        }
    }
