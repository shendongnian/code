    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        protected override void OnEnter(EventArgs e)
        {
            this.checkBox1.Checked = true;
            base.OnEnter(e); // this will raise the Enter event
        }
        protected override void OnLeave(EventArgs e)
        {
            this.checkBox1.Checked = false;
            base.OnLeave(e); // this will raise the Leave event
        }
    }
