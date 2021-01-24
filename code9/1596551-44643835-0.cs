    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button1.Clicked");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button2.Clicked");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }      
    }
