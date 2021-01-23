    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        Form2 frm2 = null;
        private void button_showForm2_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.VisibleChanged += new ventHandler(this.FormVisibilityChanged);
            frm2.Show();
        }
    
        private void FormVisibilityChanged(object sender, EventArgs e)
        {
           MessageBox.Show("Form2 is hidden. Continue processing next line of code");
        }
    }
