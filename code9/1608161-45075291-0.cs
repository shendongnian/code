    public MainWindow()
    {
        this.vm = new MyViewModel();
        this.DataContext = this.vm;
        this.InitializeComponent();
        this.vm.AsychronousFunctionToCallDatabase();
    }
