    public MainWindow()
        {
            InitializeComponent();
            var vm = this.TryFindResource("mainVM");
            if(vm != null)
            {
                this.DataContext = vm;
            }
        }  
