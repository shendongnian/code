    private DateTime _selDate;
    public DateTime SelDate {
        get { return _selDate; }
        set {
            if (value.Equals(_selDate)) return;
            /*
                here you could validate
            */
            _selDate = value;
            OnPropertyChanged(); //this updates view if changes done programmatically in your ViewModel (that implements INotifyPropertyChanged)
        }
    }
