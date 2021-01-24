    public partial class Form2 : Form
    {
        Form1 MainForm;
        public Form2(Form1 form)//This is why you need to give "this" as parameter
        {
            InitializeComponent();
            MainForm = form;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Here you call your function and send the data to fill the DataGridView
            List<string> listOfData = new List<string> {"someDataA", "someDataB"};
            MainForm.SomeFunction(listOfData);
            this.Close();
        }
    }
