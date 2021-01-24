    public partial class Form2 : Form
    {
        public Form2()
        {
            //To reset our temporary store on load
            Global.ResetGridData();
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Send data from form 2 to form 1
            Form1 b = new Form1(dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
            dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
            dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
            dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            b.ShowDialog();
        }
    }
