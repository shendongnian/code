    public MainWindowViewModel()
    {
        // Initialize the command for the add button click
        addName = new DelegateCommand(o => DoAddName((string)o));
        // Assign database collection entries
        Names = new ObservableCollection<string>(DBHandler.GetInstance().Names);
    }
    public void DoAddName(String name)
    {
        Names.Add(name);
        /*
            Update database here
        */
    }
    DelegateCommand addName;
    //  Never, never, NEVER NEVER NEVER NEVER touch _names other than in the 
    //  get and set blocks of Names. 
    //  And make the set private. It should be kept in sync with the database, so 
    //  don't let any other class but this one mess with it. 
    private ObservableCollection<string> _names = new ObservableCollection<string>();
    public ObservableCollection<string> Names
    {
        get { return _names; }
        private set { 
            if (_names != value)
            {
                _names = value; 
                NotifyPropertyChanged();
            }
        }
    }
