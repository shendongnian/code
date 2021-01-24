    public MainWindowViewModel()
    {
        // Initialize the command to add a name
        _addNameCommand = new DelegateCommand<string>(DoAddName);
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
    ICommand _addName;
    //  Don't name anything "button" in your viewmodel; it's a bad habit to think 
    //  that way. It's just a command. If the view wants to use a button to invoke 
    //  it, that's the view's business. The viewmodel just makes stuff available. 
    public ICommand AddNameCommand
    {
        get {
            Debug.WriteLine("getting AddNameCommand");
            return _addNameCommand; 
        }
    }
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
