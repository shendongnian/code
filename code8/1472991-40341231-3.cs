    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> randomCodes = new List<string>();
            string testVariable = SetRandomCode.setCode(randomCodes);
            MessageBox.Show(testVariable);
        }
    }
