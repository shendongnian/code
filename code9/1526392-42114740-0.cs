    public partial class Actions : Form
    {
        private Data myData;
        public Actions()
        {
            myData = new Data();
            myData.State = "California";
            //the best state :D\\
            InitializeComponent();
        }
    
        private void Actions_Load(object sender, EventArgs e)
        {
            testLabel.Text = myData.State;
        }
    }
