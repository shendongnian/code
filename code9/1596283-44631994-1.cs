    public MainWindow()
    {
        InitializeComponent();
        SysCheckDataGridSource = new ObservableCollection<SystemCheckingNormal>();
        DataContext = this;
    }
