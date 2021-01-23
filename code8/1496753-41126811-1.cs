    protected void OnCurrentTimeChanged()
    {
        OnPropertyChanged("CurrentTime");
        OnPropertyChanged("CurrentYear");
        OnPropertyChanged("CurrentDayOfYear");
        OnPropertyChanged("CurrentHour");
        OnPropertyChanged("CurrentMinute");
        OnPropertyChanged("CurrentSecond");
    }
    public DateTime CurrentTime
    {
        get { return DateTime.FromOADate(NowTime[CurrentIteration]); }
        set
        {
            if ((value < FirstTime) || (value > LastTime))
            {
                CurrentTime = FirstTime;
            }
            else
            {
                NowTime[CurrentIteration] = value.ToOADate();
            }
            OnCurrentTimeChanged();
        }
    }
    private int _currentIteration;
    public int CurrentIteration //used to hold current index of the list of data fields
    {
        get { return _currentIteration; }
        set
        {
            _currentIteration = value;
            OnPropertyChanged("CurrentIteration");
            OnCurrentTimeChanged();
        }
    }
