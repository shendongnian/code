     int _racesIndex;
    public int RacesIndex
    {
        get
        {
            return _racesIndex;
        }
        set
        {
            if (_racesIndex != value)
            {
                _racesIndex = value;
                // trigger some action to take such as updating other labels or fields
                Id = racelist[value].RaceId;
                OnPropertyChanged("RacesIndex");
            }
        }
    }
