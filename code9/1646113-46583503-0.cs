    public partial class SomeForm : Form
    {
        Form overlay;
        public SomeForm()
        {
            InitializeComponent();
            this.overlay = new Form();
            overlay.Owner = this;
            overlay.StartPosition = FormStartPosition.Manual;
            overlay.FormBorderStyle = FormBorderStyle.None;
            overlay.BackColor = Color.Blue;
            this.LocationChanged += SomeForm_LocationChanged;
            this.SizeChanged += SomeForm_SizeChanged;
            this.FormClosed += SomeForm_FormClosed;
            this.Load += SomeForm_Load;
        }
        private void SomeForm_Load(object sender, EventArgs e)
        {
            overlay.Size = this.ClientSize;
            overlay.Location = this.PointToScreen(new Point(0, 0));
            overlay.Show();
        }
        private void SomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            overlay.Close();
        }
        private void SomeForm_SizeChanged(object sender, EventArgs e)
        {
            overlay.Size = this.ClientSize;
        }
        private void SomeForm_LocationChanged(object sender, EventArgs e)
        {
            overlay.Location = this.PointToScreen(new Point(0,0));
        }
    }
