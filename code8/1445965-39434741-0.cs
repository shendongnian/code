    public partial class MainWindow : Window
    {
        private WrenchViewModel wrench;
        private MeasurementViewModel measurements;
     
        public MainWindow()
        {
            InitializeComponent();
            wrench = new WrenchViewModel();
            measurements = new MeasurementViewModel();
        }
        private void modelSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wrench.GetWrench(modelSelector.SelectedItem);
        }
    }
