    // Property, that shows if all Items need to be checked
    private bool _checkAllDemandLicenses;
    public bool CheckAllDemandLicenses
    {
        get
        {
            return _checkAllDemandLicenses;
        }
        set
        {
            _checkAllDemandLicenses = value;
     
            foreach(DemandLicense d in DemandLicenses)
            {
                // Set the property, that is bound to the row level checkbox
                d.Selected = value;
            }
            
            OnPropertyChanged("CheckAllDemandLicenses"); // Or whatever your implementation for INotifyPropertyChanged is
            OnPropertyChanged("DemandLicenses");
        }
    }
