    public partial class Form1 : Form
    {
        ToolTip toolTip1 = new ToolTip();
        public Form1()
        {
            //InitializeComponent();
            this.Text = "Form1";
            this.IsMdiContainer = true;
            var f1 = new SampleForm() { Text = "Some Form", MdiParent = this };
            f1.NonClientMouseHover += child_NonClientMouseHover;
            f1.Show();
            var f2 = new SampleForm() { Text = "Some Other Form", MdiParent = this };
            f2.NonClientMouseHover += child_NonClientMouseHover;
            f2.Show();
        }
        void child_NonClientMouseHover(object sender, EventArgs e)
        {
            var f = (Form)sender;
            var p = f.PointToClient(f.Parent.PointToScreen(f.Location));
            p.Offset(0, -24);
            toolTip1.Show(f.Text, f, p, 2000);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            toolTip1.Dispose();
            base.OnFormClosed(e);
        }
    }
