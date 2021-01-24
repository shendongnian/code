    public partial class MainForm : Form
    {
        public void hidePanels()
        {
            welcomePanel.Visible = false;
            homePanel.Visible = false;
            historyPanel.Visible = false;
            savePanel.Visible = false;
        }
        public MainForm()
        {
            InitializeComponent();
            Load += new EventHandler(MainForm_Load);
            homePanel.Location = welcomePanel.Location;
            historyPanel.Location = welcomePanel.Location;
            savePanel.Location = welcomePanel.Location;        
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            hidePanels();
            welcomePanel.Visible = true;
        }
    
        private void homeButton_Click(object sender, EventArgs e)
        {
            hidePanels();
            homePanel.Visible = true;
        }
        ..... and so on ...
    }
