    public partial class Form26_10 : Form
    {
        private Pen CustomPen;
        public Form26_10()
        {
            InitializeComponent();
            CustomPen = new Pen(Color.Black, scrollValue);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            CustomPen.Width = trackBar1.Value;
        }
    }
