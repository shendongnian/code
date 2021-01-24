    public partial class SearchEngineForm1 : Form
    {
        public SearchEngineForm1()
        {
            InitializeComponent();
        }
        public string searchAddress;
        private void SearchEngineForm1_Load(object sender, EventArgs e)
        {
            webBrowser1.Url= new Uri(searchAddress);
        }
    }
