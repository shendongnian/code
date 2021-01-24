    public class ProjectInformation
    {
        public int Roundedhour1 { get; set; }
    }
    public partial class MainWindow : Window
    {
        private ObservableCollection<ProjectInformation> _sourceCollection = new ObservableCollection<ProjectInformation>();
        public MainWindow()
        {
            InitializeComponent();
            lstbxindex.ItemsSource = _sourceCollection;
            //add
            ProjectInformation item = new ProjectInformation() { Roundedhour1 = 1 };
            _sourceCollection.Add(item);
        }
        private void items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //remove
            _sourceCollection.Remove(lstbxindex.SelectedItem as ProjectInformation);
        }
    }
