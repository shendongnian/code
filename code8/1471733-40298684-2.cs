    private readonly FrameworkElement _academicView;
    private readonly FrameworkElement _studentView;
    public MainWindow()
    {
        InitializeComponent();
        _academicView = new AcademicView();
        _studentView = new StudentView();
        content.Content = _academicView; // set the default view
    }
    private void StudentMenuItem_Click(object sender, RoutedEventArgs e)
    {
        content.Content = _studentView;
    }
    private void AcademicMenuItem_Click(object sender, RoutedEventArgs e)
    {
        content.Content = _academicView;
    }
