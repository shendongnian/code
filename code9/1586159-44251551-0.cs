    public partial class Main_Program : Form
    {
        public Main_Program()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show(this); // pass in THIS instance of Main_Program as the "Owner"
        }
    }
