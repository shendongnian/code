    public partial class DialogControl : UserControl
    {
        TaskCompletionSource<DialogResult> _tcs;
        public DialogControl()
        {
            InitializeComponent();
            this.Visible = false;
        }
        public Task<DialogResult> ShowModalAsync()
        {
            _tcs = new TaskCompletionSource<DialogResult>();
            this.Visible = true;
            this.Dock = DockStyle.Fill;
            this.BringToFront();
            return _tcs.Task;
        }
        private void btmCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _tcs.SetResult(DialogResult.Cancel);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            _tcs.SetResult(DialogResult.OK);
            this.Visible = false;
        }
        public string UserName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
    }
