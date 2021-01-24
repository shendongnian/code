    private string _DocumentPath;
    public string DocumentPath
    {
        get { return _DocumentPath; }
        set
        {
            _DocumentPath = value;
            OnPropertyChanged("DocumentPath");
        }
    }
    public MyViewModel()
    {
        DocumentPath = "myDocPath";
    }
