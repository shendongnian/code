    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var frm3 = new Form3();
            var dr = frm3.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                // form3 failed
            }
            else if (dr == DialogResult.OK)
            {
                // form3 completed
            }
            frm3.Close();
        }
    }
