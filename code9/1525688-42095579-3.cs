    public ObservableCollection<string> Websites { get; set; }
    
    public ICommand AddNewStringCommand => new RelayCommand(AddNewString);
    
    private void AddNewString()
    {
        Websites.Add(string.Empty);
    }
