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
            dataGridView1.Rows.Clear();
            foreach(string data in someData)
            {
                dataGridView1.Rows.Add(data);
            }
        }
    }
