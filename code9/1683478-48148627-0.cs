    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
	    //set the DataContext of the window itself or the DataGrid
            dgResults.DataContext = new ViewModel();
        }
    }
    public class ViewModel
    {
        public ViewModel()
	    {
	        SampleData = new List<SampleData>();
            SampleData.Add(new SampleData() { WellID = "1" });
            SampleData.Add(new SampleData() { WellID = "2" });
	    }
        public IEnumerable<SampleData> SampleData { get; }
    }
