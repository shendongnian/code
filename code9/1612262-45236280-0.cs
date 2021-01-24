    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Process> ProcList = new List<Process>();
            ProcList = Process.GetProcesses().ToList();
        }//Add break point here.
    }
