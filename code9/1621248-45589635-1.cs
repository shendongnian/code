    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.ListItems.Add(new MatchItemViewModel() { SomeText = "Red dogs are strange" });
        vm.ListItems.Add(new MatchItemViewModel() { SomeText = "I'm hungry" });
        vm.ComboboxItems.Add("What do you think of red dogs?");
        vm.ComboboxItems.Add("Current state of mind");
        grid1.DataContext = vm;
    }
