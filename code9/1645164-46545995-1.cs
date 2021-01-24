       public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            vm.BuildData();
            DataConext = vm;
        }
