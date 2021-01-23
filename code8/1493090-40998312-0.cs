    public partial class MainWindow : Window
    {
        private ManualResetEvent theThreadShouldStop;
        private Thread TheThread { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
    
            // ??? This should be set through designer!!
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;
            theThreadShouldStop = new ManualResetEvent(false);
        }
    
        private void MainWindow_Loaded(object sender, EventArgs e)
        {
            // Create the (background-)thread and start it
            TheThread = new Thread(() => Logic.DoSomething(theThreadShouldStop));
            TheThread.IsBackground = true;
            TheThread.Start();
        }
    
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            // Close Thread if existent.
            theThreadShouldStop.Set();
            TheThread.Join();        
            theThreadShouldStop.Close();
        }
    }
