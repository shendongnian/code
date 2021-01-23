    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
		    ...
            this.Enter += new System.EventHandler(this.OnEnterFocus);
            this.Leave += new System.EventHandler(this.OnLeaveFocus);
        }
        private void OnEnterFocus(object sender, EventArgs e)
        {
            this.checkBox1.Checked = true;
        }
        private void OnLeaveFocus(object sender, EventArgs e)
        {
            this.checkBox1.Checked = false;
        }
    }
