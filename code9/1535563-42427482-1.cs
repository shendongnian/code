    public AddRegion()
    {
        var vm = new WineDatabase.ViewModel.ViewModelAddRegion();      
        vm.CountryList = vm.GetCountryList();
        DataContext = vm;
        InitializeComponent();
    }
