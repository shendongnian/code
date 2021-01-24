    public partial class Form2 : Form
    {
        Form1 MainForm;
        public Form2(Form1 form)
        {
            InitializeComponent();
            MainForm = form;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.SomeFunction("somedata");
            this.Close();
        }
    }
