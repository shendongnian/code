    ViewModelLine _viewModel;
    private List<Brush> _brushes;
    Random _rand;
    public MainWindow()
    {
        this.InitializeComponent();
        _viewModel = new ViewModelLine();
        this.DataContext = _viewModel;
        _rand = new Random();
        _brushes = new List<Brush>();
        var props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
        foreach (var propInfo in props)
            _brushes.Add((Brush)propInfo.GetValue(null, null));
        int interval = 10;
        Task.Factory.StartNew(() =>
        {
            while (true)
            {
                 System.Threading.Thread.Sleep(interval);
                 Dispatcher.Invoke(new Action(() => AddNew()));
            }
         });
    }
    void AddNew()
    {
        int w = (int)ActualWidth;
        int h = (int)ActualHeight;
        _viewModel.Models.Add(new ModelLine() {
             X1 = _rand.Next(1, w),
             X2 = _rand.Next(1, w),
             Y1 = _rand.Next(1, h),
             Y2 = _rand.Next(1, h),
             Thickness = _rand.Next(1, 4),
              Opacity = _rand.NextDouble(),
              Brush = _brushes[_rand.Next(_brushes.Count)]
        });
    }
