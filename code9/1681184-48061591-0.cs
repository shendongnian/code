    public partial class MainForm : Form
    {
        private WinFormsBrowserView browserView;
        public MainForm()
        {
            InitializeComponent();
            browserView = new WinFormsBrowserView() {Dock = DockStyle.Fill};
            browserView.MouseDown += BrowserView_MouseDown;
            this.Controls.Add(browserView);
        }
        private void BrowserView_MouseDown(object sender, MouseEventArgs e)
        {
            int clickX = e.X;
            int clickY = e.Y;
        }
    }
