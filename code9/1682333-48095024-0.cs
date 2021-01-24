    public partial class Form2 : Form
    {
        public string _filename;
        public Form2(string text, string filename)
        {
            InitializeComponent();
            richTextBox1.Text = text;
            _filename = filename;
        }
