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
     
    //Just declare a prop into Form2 a set it with the value you need
    public partial class Form2 : Form
    {
        public string TextBoxChecked { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                TextBoxChecked = "Checkbox_1_checked";
            else
                TextBoxChecked = "Checkbox_1_unchecked";
        }
    }
