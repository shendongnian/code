    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                Visible = false;
            }
        }
    }
