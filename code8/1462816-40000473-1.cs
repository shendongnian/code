    public partial class ListSelector : Form
    {
        private string windowName = Form1.typeOfModuleAdded;
        private List<IOModule> innerIOList;
        IOModule cardAdded = null;
        public List<IOModule> CardList 
        {
             get 
             {
                  return innerIOList; 
             }
             set
             {
                  innerIOList = value;
                  InitializeList();
             }
        }
        public ListSelector()
        {
            this.Text = windowName;
            InitializeComponent();
        }
