    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.UserData.Add(new UserData { Text = "User 1" });
        vm.UserData.Add(new UserData { Text = "User 2" });
        vm.UserData.Add(new UserData { Text = "User 3" });
        vm.SelectedUserData = vm.UserData[1];
        DataContext = vm;
    }
