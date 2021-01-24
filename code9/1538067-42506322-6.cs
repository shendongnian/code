    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
            
        }
        public void SomeFunction(string someData)
        {
            MessageBox.Show(someData);
        }
    }
