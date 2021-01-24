    public partial class Form2 : Form
    {
        public delegate void NewText(string item);
        public event NewText NewTextChanged;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (NewTextChanged != null)
            {
                NewTextChanged(textBox1.Text);
            }
        }
    }
