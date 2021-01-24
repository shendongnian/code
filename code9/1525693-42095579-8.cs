    public ObservableCollection<Website> Websites { get; set; } = new ObservableCollection<Website>();
    
    public ICommand AddNewStringCommand => new RelayCommand(AddNewString);
    
    private void AddNewString()
    {
        Websites.Add(new Website {Name = "new website"});
    }
