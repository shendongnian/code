    public List<object> SelectedFeatures
    {
        get { return _SelectedFeatures; }
        set
        {
            _SelectedFeatures = value;
            NotifyPropertyChanged("SelectedFeatures");
        }
    }
