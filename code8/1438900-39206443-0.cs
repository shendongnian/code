    public ObservableCollection<Models.ComboboxItem> NotificationMode
    {
        get
        {
            return _notificationMode;
        }
        set
        {
            _notificationMode = value;
            OnPropertyChanged("NotificationMode");
        }
    }
