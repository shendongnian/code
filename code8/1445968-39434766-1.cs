     public partial class MainWindow : Window
     {
 
    private WrenchViewModel _wrench = new WrenchViewModel();
     private  MeasurementViewModel _measurements = new MeasurementViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void modelSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _wrench.GetWrench(modelSelector.SelectedItem);
        }
    }
