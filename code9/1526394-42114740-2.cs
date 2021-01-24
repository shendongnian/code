    public partial class Actions : Form
    {
        private Data myData;
        public Actions(Data otherDataObject)
        {
            myData = otherDataObject;
            testLabel.Text = myData.State; //here
            InitializeComponent();
        }
        private void Actions_Load(object sender, EventArgs e)
        {
            testLabel.Text = myData.State; //or here
        }
    }
