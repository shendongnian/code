    public partial class ControlDesigner: UserControl
        {
        public string CustomerName{ get; set; }
        public MainWindow()
        {
           // Set Value
           // CustomerName = "Test Name";
            InitializeComponent();
            this.DataContext = this;
        }
    }
