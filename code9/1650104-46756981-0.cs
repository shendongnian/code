    public partial class Form2 : Form
    {
        Form3 frm3;
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            frm3 = new Form3();
            DialogResult dr = frm3.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                frm3.Close();
            }
            else if (dr == DialogResult.OK)
            {
                var dataFromForm3 = frm3.getData();
                frm3.Close();
            }
        }
    }
