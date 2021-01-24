    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            MyInitializeComponent();
        }
    
        private void MyInitializeComponent()
        {
            this.Paint += MyUserControl_Paint;
        }
    
        private void MyUserControl_Paint(object sender, PaintEventArgs e)
        {
            // Draw a border around the outside border of the control
            var pen = new Pen(Color.Black, 2f);
            e.Graphics.DrawRectangle(pen, this.ClientRectangle);
        }
    }
