    public partial class Form1 : Form
    {
        private static Form1 frmReference;
        private static void WriteToMyRichTextBox(string what)
        {
            frmReference.richTextBox1.AppendText(what);
            frmReference.richTextBox1.AppendText(Environment.NewLine);
        }
        public Form1()
        {
            InitializeComponent();
            frmReference = this;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WriteToMyRichTextBox(DateTime.Now.ToString());
        }
    }
