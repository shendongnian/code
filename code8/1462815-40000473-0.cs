    public partial class ListSelector : Form
    {
        private string windowName = Form1.typeOfModuleAdded;
        IOModule cardAdded = null;
        public List<IOModule> CardList {get; set;}
        public ListSelector()
        {
            this.Text = windowName;
            InitializeComponent();
            InitializeList();
        }
