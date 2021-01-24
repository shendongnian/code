    private static bool _isPrivStateMinimized;
    private static int _left, _top;
    public MainWindow()
    {
        InitializeComponent();
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
    }
    protected override void OnStateChanged(EventArgs e)
    {            
        base.OnStateChanged(e);
        if (WindowState == WindowState.Minimized)
        {
            _isPrivStateMinimized = true;
            return;
        }
        if (_isPrivStateMinimized)
        {
            if(WindowState == WindowState.Maximized)
            {
                _left = Left;
                Left = 0;
                _top = Top;
                Top = 0;
            }
            else
            {
                Left = _left;
                Top = _top;
            }
        }
        _isPrivStateMinimized = false;
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
    
    private void ExitApplication(object sender, RoutedEventArgs e)
    {
        Close();
    }
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }
    private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
            NormalBtn.Visibility = Visibility.Collapsed;
            MaximizeBtn.Visibility = Visibility.Visible;
            return;
        }
        WindowState = WindowState.Maximized;
        MaximizeBtn.Visibility = Visibility.Collapsed;
        NormalBtn.Visibility = Visibility.Visible;
    }
