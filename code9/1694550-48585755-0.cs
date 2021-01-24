    bool _state;
    [TypeConverter(typeof(NullableBoolConverter))]
    public bool? State
    {
       get { return _state }
       set { _state = value; RaisePropertyChanged(); }
    }
