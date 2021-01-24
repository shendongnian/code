    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //used to generate random values
            var r = new Random();
            var t = 0d;
            //lets instead plot elapsed milliseconds and value
            var mapper = Mappers.Xy<MeasureModel>()
                .X(x => x.ElapsedMilliseconds)
                .Y(x => x.Value);
            //save the mapper globally         
            Charting.For<MeasureModel>(mapper);
            Values = new ChartValues<MeasureModel>();
            var sw = new Stopwatch();
            sw.Start();
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    
                    //we add the lecture based on our StopWatch instance
                    Values.Add(new MeasureModel
                    {
                        ElapsedMilliseconds = sw.ElapsedMilliseconds,
                        Value = t += r.Next(0,10)
                    });
                }
            });
            DataContext = this;
        }
        public ChartValues<MeasureModel> Values { get; set; }
    }
    public class MeasureModel
    {
        public double ElapsedMilliseconds { get; set; }
        public double Value { get; set; }
    }
