    public partial class Form2 : Form
    {
        public EventHandler ChangeLabelText;
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sText = textBox1.Text;
            ChangeLabelText(sText, null);
        }
    }
