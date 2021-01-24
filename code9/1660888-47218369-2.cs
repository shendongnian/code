    public partial class MainWindow : Window
    {
        //the timer doesn't need to be static
        //and since we are going to update the UI when the timer elapses,
        //(in LoadData)
        //we should use a dispatchertimer
        private DispatcherTimer aTimer;
    
        private List<tw__Towar> someData;
    
        public MainWindow()
        {
            InitializeComponent();
            //set up the timer straight away
            aTimer = new DispatcherTimer();
            aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Interval = TimeSpan.FromSeconds(300); //300 seconds = 5 minutes
            aTimer.Start();
        }
    
        private void Generate()
        {
            LoadData();
            string path = @"c:\some path";
    
            var createFile = someData.Select(k => $"{k.tw_Id}\t" + $"{k.column}\t" + $"{k.column2}\t" + $"{k.column3}\t"
              );
            File.WriteAllLines(path, createFile);
            Process.Start(path);
        }
    
        private void OnTimedEvent(object sender, EventArgs e)
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
