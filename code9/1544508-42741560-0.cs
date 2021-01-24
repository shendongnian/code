    public partial class FrmConnect : Form
    {
        private FrmMain mainForm;
        public FrmConnect(FrmMain frmMain)
        {
            this.mainForm = frmMain;
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            FrmMain.Connected = true;
            mainForm.consoleLog("Connected");
        }
    }
