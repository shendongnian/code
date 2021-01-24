    public frmUserControl : Form
    {
        private UserControl control;
    
        public frmUserControl(UserControl control)
        {
            this.control = control;
            this.Load += frmUserControl_Load;
        }
    
        public frmUserControl_Load(object sender, EventArgs e)
        {
            this.Controls.Add(control);
        }
    }
