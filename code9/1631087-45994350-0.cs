    public ExampleViewModel()
    {
        AddNewCommand = new DelegateCommand(AddNew, CanAdd);
    }
    public ICommand AddNewCommand { get; private set; }
