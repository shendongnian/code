    public SeriesCollection SeriesCollection { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();
    
        var mapper = Mappers.Xy<double>()
                        .X((value, index) => index)
                        .Y((value, index) => Math.Log(value, 10));
    
        SeriesCollection = new SeriesCollection(mapper)
        {
            new ColumnSeries
            {
                Values = new ChartValues<double>{500,30,10}
            }
        };
    
        DataContext = this;
    }
