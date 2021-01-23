    using System.Linq;
    ...
    public MainWindow()
    {
        InitializeComponent();
        DataContext = Enumerable
            .Range(1, 151)
            .Select(i => string.Format("pack://application:,,,/Images/{0:000}.jpg", i));
    }
