    public ObservableCollection<Meeting> Meetings
    {
        get
        {
            return meetings;
        }
        set
        {
            meetings = value;
            OnPropertyChanged("ListProperty");
            OnPropertyChanged("Meetings");
        }
    }
