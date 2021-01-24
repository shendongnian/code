    public partial class MainWindow : Window
    {
        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));
        //public SerialPort serialPort1 = new SerialPort();
        //public string rx_str = "";
        //public string rx_str_copy;
        //public int a;
        public double x, y;
        public ObservableCollection<ChartData> chartData { get; set; }
        ChartData objChartData;
        Thread myThread;
        Random r;
        int range = 50;
        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
            DataContext = this;
            /*
            string[] port = SerialPort.GetPortNames();
            foreach (string a in port)
            {
                comboPorts.Items.Add(a);
            }
            Array.Sort(port);
            comboPorts.Text = port[0];
            */
            objChartData = new ChartData();
            chartData = new ObservableCollection<ChartData>();
            chartData.Add(objChartData);
            //chart1.DataContext = chartData;
            myThread = new Thread(new ThreadStart(Run));
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            myThread.Start();
        }
        public void Run()
        {
            while (true)
            {
                //serialPort1.Write("a");
                //rx_str = serialPort1.ReadTo("b");
                //rx_str_copy = rx_str;
                //x = a;
                //y = Double.Parse(rx_str_copy, CultureInfo.InvariantCulture);
                //a++;
                Dispatcher.Invoke(new Action(delegate
                {
                    chartData.Add(new ChartData()
                    {
                        Value1 = x,
                        Value2 = r.NextDouble(),
                        //Value2 = y
                    });
                    MinValue = x < range ? 0 : x - range;
                    x++;
                }));
                Thread.Sleep(50);
            }
        }
    }
