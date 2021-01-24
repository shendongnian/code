    public partial class SensorChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public DateTime InitialDateTime { get; set; }
        public Func<double, string> Formatter { get; set; }
        public SensorChart()
        {
            InitializeComponent();
            this.SetChartModelValues();
            this.DataContext = this;
        }
        private void SetChartModelValues()
        {
            var dayConfig = Mappers.Xy<ChartModel>()
                               .X(dayModel => dayModel.DateTime.Ticks)
                               .Y(dayModel => dayModel.Value);
            DateTime now = DateTime.Now;
            this.SeriesCollection = new SeriesCollection(dayConfig)
            {
                new LineSeries()
                {
                    Values = new ChartValues<ChartModel>()
                    {
                        new ChartModel(now.AddSeconds(5), 3),
                        new ChartModel(now.AddSeconds(10), 6),
                        new ChartModel(now.AddSeconds(15), 8),
                        new ChartModel(now.AddSeconds(20), 4),
                        new ChartModel(now.AddSeconds(55), 7),
                        new ChartModel(now.AddSeconds(60), 2),
                        new ChartModel(now.AddSeconds(65), 6),
                        new ChartModel(now.AddSeconds(70), 8),
                        new ChartModel(now.AddSeconds(75), 4),
                        new ChartModel(now.AddSeconds(80), 7),
                        new ChartModel(now.AddSeconds(105), 3),
                        new ChartModel(now.AddSeconds(110), 6),
                        new ChartModel(now.AddSeconds(115), 8),
                        new ChartModel(now.AddSeconds(120), 4),
                        new ChartModel(now.AddSeconds(155), 7),
                        new ChartModel(now.AddSeconds(160), 2),
                        new ChartModel(now.AddSeconds(165), 6),
                        new ChartModel(now.AddSeconds(170), 8),
                        new ChartModel(now.AddSeconds(175), 4),
                        new ChartModel(now.AddSeconds(180), 7),
                    }
                }
            };
            this.InitialDateTime = now;
            this.Formatter = value => new DateTime((long)value).ToString("yyyy-MM:dd HH:mm:ss");
        }
    }
