    public partial class Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PatientWindowView.DataContext = new PatientWindowViewModel();
            
        }
    }
