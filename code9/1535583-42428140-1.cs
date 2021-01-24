    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string searchAddress;
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Url= new Uri(searchAddress);
        }
