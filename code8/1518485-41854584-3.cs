    using System.Linq;
    ...
    public MainWindow()
    {
        // The window components are initialized.
        InitializeComponent();
        // DataContext gets the viewmodel.
        DataContext = vm;
        vm.StepDataSource.Add(new StepData("<", 0, 0, vm.LowerComparers2.FirstOrDefault(x => x.ArithmeticSignKey == "1")));
        vm.StepDataSource.Add(new StepData("<=", 0.1, 0.8, vm.LowerComparers2.FirstOrDefault(x => x.ArithmeticSignKey == "2")));
        vm.StepDataSource.Add(new StepData("<", 0.2, 1.2, vm.LowerComparers2.FirstOrDefault(x => x.ArithmeticSignKey == "1")));
        vm.StepDataSource.Add(new StepData("<=", 0.3, 1.4, vm.LowerComparers2.FirstOrDefault(x => x.ArithmeticSignKey == "2")));
        ChartDataRefresh();
        ...
    } 
