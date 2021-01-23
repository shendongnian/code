    public partial class Form1 : Form
    {
        string Q = "HALLO";
        string hashtag = "#";
        public Form1()
        {
            InitializeComponent();
            tB1.Text = Q;
        }
        private void bT1_MouseHover(object sender, EventArgs e)
        {
            tB1.Text += hashtag;
        }
    }
