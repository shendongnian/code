    namespace WindowsFormsApp1
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
    
    
    
            private void PlusProduct_Click(object sender, EventArgs e)
            {
                Form2 newForm = new Form2();
                newForm.Show();
            }
        }
    }
    
