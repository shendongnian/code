    public ICommand SearchCommand {get; private set; }
    
    bool _canSearch = true;
    public bool CanSearch 
    { 
        get { return _canSearch; } 
        private set { 
            _canSearch = value;
            ((Command)SearchCommand).ChangeCanExecute(); 
        }
    }
    
    public SearchPageViewModel()
    {
        SearchCommand = new Command(() => DoSearchStuff(), () => CanSearch)
    }
    
    void DoSearchStuff()
    {
        CanSearch = false;
        // long searching stuff
        CanSearch = true;
    }
