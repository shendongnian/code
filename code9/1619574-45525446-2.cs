    public MainWindow()
    {
        InitializeComponent();
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
    }
    protected override void OnStateChanged(EventArgs e)
    {
        base.OnStateChanged(e);
        BringIntoView();
    }
    private void MaximizeState(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Maximized;
        MaximizeBtn.Visibility = Visibility.Collapsed;
        NormalBtn.Visibility = Visibility.Visible;
    }
    private void NormalState(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Normal;
        NormalBtn.Visibility = Visibility.Collapsed;
        MaximizeBtn.Visibility = Visibility.Visible;
    }
    private void MinimizeState(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }
