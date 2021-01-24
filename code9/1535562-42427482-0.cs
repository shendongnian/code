    public AddRegion()
    {
        var vm = new WineDatabase.ViewModel.ViewModelAddRegion();      
        vm.GetCountryList();
        DataContext = vm;
        InitializeComponent();
    }
