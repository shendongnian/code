    private ObservableCollection<Job> _allJobs;
    public ObservableCollection<Job> AllJobs
    {
        get
        {        
            return _allJobs;
        }
        set
        {
            if (value != _allJobs)
            {
                _allJobs = value;
                OnPropertyChanged("AllJobs");
            }
        }
    }
