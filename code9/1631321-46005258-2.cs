    public MainViewModel()
    {
        MouseEnter = new RelayCommand<string>(SetHelpText);
        MouseLeave = new RelayCommand<string>(ClearHelpText);
    }
