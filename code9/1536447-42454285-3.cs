    public RelayCommand UpdateAMSCommand { get; private set; }
    public AMSSettingsViewModel(IEventAggregator eventAggregator)
    {
        UpdateAMSCommand = new RelayCommand(OnUpdateAMS, CanUpdateAms);
        CustomAMSOffices.ListChanged += listChanged;
        CustomAMSContacts.ListChanged += listChanged;
    }
    private void listChanged(object sender, ListChangedEventArgs e)
    {
        UpdateAMSCommand.RaiseCanExecuteChanged();
    }
    private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
    {
        UpdateAMSCommand.RaiseCanExecuteChanged();
    }
    
    // This will simply flip from true to false every time it is called.
    private bool _canupdate = false;
    private bool CanUpdateAms()
    {
        _canupdate = !_canupdate;
        return _canupdate;
    }
