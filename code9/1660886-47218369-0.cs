    public partial class MainWindow : Window
    {
        //the timer doesn't need to be static
        private Timer aTimer;
    
        private List<tw__Towar> someData;
    
        public MainWindow()
        {
            InitializeComponent();
            //set up the timer straight away
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = some time;
            aTimer.Enabled = true;
            aTimer.Start();
        }
    
        private void Generate()
        {
            //we need to refresh our data before we write it to the text file
            LoadData();
            string path = @"c:\some path";
    
            var createFile = someData.Select(k => $"{k.tw_Id}\t" + $"{k.column}\t" + $"{k.column2}\t" + $"{k.column3}\t"
              );
            File.WriteAllLines(path, createFile);
            Process.Start(path);
        }
    
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Generate();
            Console.WriteLine("It works");
        }
    
        private void LoadData()
        {
            DataClasses1DataContext cd = new DataClasses1DataContext();
            someData = (from p in cd.datavbase where p.column != null && p.column != "" select p).ToList();
            GT1.ItemsSource = someData;
        }
    }
