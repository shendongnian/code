    private string _details;
    public string Details
    {
        get { return _details; }
        set
        {
            if (SetProperty(ref _details, value))
            {
                RaisePropertyChanged(() => Details);
            }
        }
    }
