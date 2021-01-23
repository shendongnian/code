    public partial class Form2 : Form
    {
        public event EventHandler ChangeLabelText;
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            (this.Owner as Form1).label1.Text = textBox1.Text;
        }
    }
