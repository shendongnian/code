    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("Tom");
            listBox1.Items.Add("Dick");
            listBox1.Items.Add("Harry");
            listBox1.Items.Add("Henry");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox oTextBox = (TextBox)sender;
            int iListIndex = oTextBox.TextLength == 0 ? -1 : listBox1.FindString(oTextBox.Text);
            listBox1.SelectedIndex = iListIndex;
        }
    }
