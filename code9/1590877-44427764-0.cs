    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmTest frmTest = new frmTest();
            DialogResult dr = frmTest.ShowDialog();
            if(dr == System.Windows.Forms.DialogResult.OK)
            {
                string value = frmTest.GetValue();
                MessageBox.Show(value);
            }
        }
    }
