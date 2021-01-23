    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.AddRange(new[] { "Tom", "Dick", "Harry", "Henry" });
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            listBox1.SelectedIndex = textBox.TextLength == 0 ?
                -1 : listBox1.FindString(textBox.Text);
        }
    }
