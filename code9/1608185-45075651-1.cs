    public meterreadingrecords()
    {
        this._id = string.Empty;
        this._actualmeterreading = new actualmeterreading();
       
        this._actualmeterreading.PropertyChanged += _actualmeterreading_PropertyChanged
    }
    private void _actualmeterreading_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        RaisePropertyChanged("_actualmeterreading");
    }
