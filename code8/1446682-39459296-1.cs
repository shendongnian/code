    public partial class MainForm : Form
    {
        string uid = "UID";
        public MainForm()
        {
            InitializeComponent();
        }
        void loginClick(object sender, EventArgs e)
        {
            var frm = new Form1(uid);
            this.Hide();
            frm.Show();
        }
    }
