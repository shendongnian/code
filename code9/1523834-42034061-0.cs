    public partial class MainForm : Form
    {
        // local instance of the sub form
        private ViewForm SubForm { get; set;} = null;
    
        public MainForm()
        {
            InitializeComponent();
            backGroundWorker1.RunWorkerAsync();
            InitializeCustomControls();
        }
    
        private void OpenViewWindow_Click(object sender, EventArgs e)
        {
            // if the window is instanciated
            if (SubForm != null)
            {
                SubForm.Show();                
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SubForm = new ViewForm();
        }
    }
