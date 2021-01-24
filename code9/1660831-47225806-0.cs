    public partial class MainWindow : Window
    {
        private ObservableCollection<Parameters> _viewSetList = new ObservableCollection<Parameters>();
        public ObservableCollection<Parameters> ViewSetList { get { return _viewSetList; } }
        public MainWindow()
        {
            InitializeComponent();
            //Add data to the collection
            _viewSetList.Add(new Parameters() { PARAMETER = "abc", INSTANCE = "def", UNIT = "hhshhd", VALUE = "hahha" });
            DataContext = this;
        }
    }
