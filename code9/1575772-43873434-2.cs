    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string setting = "3:20";
            string[] settingsArray = setting.Split(':');
            textBox1.Text = settingsArray[0];
            textBox2.Text = settingsArray[1];
        }
    }
