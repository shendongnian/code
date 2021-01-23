    public BaseViewModel PatientVM
    {
        get { return _patientVM; }
        set
        {
            patientVM = value;
            OnPropertyChanged();
        }
    }
