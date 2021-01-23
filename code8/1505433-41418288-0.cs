    public MainWindow()
    {
        InitializeComponent();
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            var be = theLabel.GetBindingExpression(Label.ContentProperty);
            if (be != null)
                be.UpdateTarget();
        };
        timer.Start();
    }
----------
    <Label x:Name="theLabel" Content="{Binding Event.TimeLeft}" />
