    public partial class Form1 : Form
    {
        private Form _form2 = new Form2();
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            _form2.Visible = !_form2.Visible;
        }
    }
