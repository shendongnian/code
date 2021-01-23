    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form2();
            frm.ShowDialog();
            label1.Text = frm.TextBoxChecked;
        }
    }
    public partial class Form2 : Form
    {
        public string TextBoxChecked { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxChecked = "Checkbox_1";
        }
    }
