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
            //Here you call your function and send the data to fill the DataGridView
            MainForm.SomeFunction("somedata");
            this.Close();
        }
    }
