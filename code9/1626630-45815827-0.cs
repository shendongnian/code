       public ObservableCollection<TimeBooking> TimeBookings
    {  
        get { return _timebookings; }
        set
        {
            _timebookings = value;
            OnPropertyChanged("TimeBookings");
        }
    }
