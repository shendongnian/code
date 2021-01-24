    protected void RaisePropertyChanged(string _property)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler.Invoke(this, new PropertyChangedEventArgs(_property));
        }
    }
