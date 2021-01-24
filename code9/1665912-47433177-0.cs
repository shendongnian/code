    public ICommand SearchCommand {get; private set; }
    
    bool CanSearch = true;
    
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
