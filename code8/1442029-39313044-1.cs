    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Click += TextBoxOnClick;
        }
        private void TextBoxOnClick(object sender, EventArgs eventArgs)
        {
            var textBox = (TextBox) sender;
            textBox.SelectAll();
            textBox.Focus();
        }
    }
