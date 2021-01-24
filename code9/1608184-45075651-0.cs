    public meterreadingrecords()
    {
        this._id = string.Empty;
        this._actualmeterreading = new actualmeterreading();
       
        this._actualmeterreading.PropertyChanged += ChainEvent
    }
    private void ChainEvent(String Name)
    {
        this.RaisePropertyChanged(Name);
    }
