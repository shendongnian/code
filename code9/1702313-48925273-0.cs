    public NavigationCandidates navigationCandidates { get; set; }
    public RegisterVM(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        navigationCandidates = new NavigationCandidates(this);
    }
