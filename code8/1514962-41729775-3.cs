    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void doWhenCheckBoxChange(string text)
        {
            //I'm receiving the notification indicating that the checkbox has changed
            label1.Text = text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new Form2();
            //I'm passing a callback to Form2, Here is where I say 
            //"Hey you, let me know where your checkbox change"
            frm.DoWhenCheckboxChange = doWhenCheckBoxChange;
            frm.ShowDialog();
            //label1.Text = frm.TextBoxChecked;
        }
    }
    public partial class Form2 : Form
    {
        //public string TextBoxChecked { get; set; }
        public Action<string> DoWhenCheckboxChange;
        public Form2()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //TextBoxChecked = "Checkbox_1";
            //Notify to Form1 that checkbox has changed.
            if (checkBox1.Checked)
                DoWhenCheckboxChange("Checkbox_1_checked");
            else
                DoWhenCheckboxChange("Checkbox_1_unchecked");
        }
    }
