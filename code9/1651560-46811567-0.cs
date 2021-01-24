    public MainWindow()
    {
        InitializeComponent();
        Ellipse myEllipse = new Ellipse();
        ...
        myEllipse.MouseEnter += MyEllipse_MouseEnter;
        myEllipse.MouseLeave += MyEllipse_MouseLeave;
    }
    private void MyEllipse_MouseLeave(object sender, MouseEventArgs e)
    {
        Ellipse ellipse = sender as Ellipse;
        ellipse.Fill = Brushes.Transparent;
    }
    private void MyEllipse_MouseEnter(object sender, MouseEventArgs e)
    {
        Ellipse ellipse = sender as Ellipse;
        ellipse.Fill = Brushes.Red;
    }
