    public partial class MDIParent1 : Form
    {    
        public MDIParent1()
        {
            InitializeComponent();
        }
    
        private void MDIParent1_Load(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Child Window";
    
            childForm.Show();   
            this.MainMenuStrip = new MenuStrip();
            this.MainMenuStrip.Visible = false;
        };
    }
