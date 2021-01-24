    [...]
    public ICommand LoadedCommand { get; private set; }
    public VendorsListViewModel(IUnitOfWork unitOfWork) : base() {
        UnitOfWork = unitOfWork;
        CurrentPage = 1;
        ModelsPerPage = 25;
        LoadedCommand = new RelayCommand(this.Loaded);
    }
    private void Loaded()
    {
        SetVendors();
    }
