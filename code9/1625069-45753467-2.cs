    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.Options.Add(new Option { Name = "Agudabi 1" });
        vm.Options.Add(new Option { Name = "Agudabi 2" });
        vm.Options.Add(new Option { Name = "Agudabi 3" });
        DataContext = vm;
    }
